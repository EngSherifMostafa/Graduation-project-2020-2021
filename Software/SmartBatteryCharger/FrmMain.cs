﻿using System;
using System.Linq;
using System.Drawing;
using Microsoft.Win32;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace Smart_Battery_Charger
{
    internal partial class FrmMain : Form
    {
        #region initializer

        //declare list of class RecordInfo and ReportInfo to be data source for data grid view and source for log file report
        private readonly List<RecordInfo> _recordsList;
        private readonly List<ReportInfo> _reportList;

        //declare Resource Monitor that collects data about user usage
        private readonly ResourcesMonitor _resourcesMonitor;

        //declare BindingSource to Refresh Dgv.DataSource
        private readonly BindingSource _bindingSource;

        private readonly Thread _threadUpdateResourcesUsage;

        //constructor
        public FrmMain()
        {
            InitializeComponent();
            _bindingSource = new BindingSource();
            _recordsList = new List<RecordInfo>();
            _reportList = new List<ReportInfo>();
            _resourcesMonitor = new ResourcesMonitor();

            //get battery percent at initialization time and format DateTimePickers
            lblBatteryNow.Text = @$"{_resourcesMonitor.BatteryPercent} %";
            dtpDateFrom.CustomFormat = @"dd-MM-yyyy";
            dtpDateTo.CustomFormat = @"dd-MM-yyyy";

            //enable thread that responsible for update machine info part & insert record at database
            _threadUpdateResourcesUsage = new Thread(UpdateResourcesUsage)
            {
                Name = "threadUpdateResourcesUsage",
                IsBackground = true,
                Priority = ThreadPriority.Lowest
            };

            //add SystemEvents_PowerModeChanged event using Microsoft.Win32 API
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            //add GetBatteryPercentage to PercentChanged event
            _resourcesMonitor.BatteryMonitor.PercentChanged += GetBatteryPercentage;

            //add InsertAtChange to PercentChanged event
            _resourcesMonitor.BatteryMonitor.PercentChanged += InsertAtChange;

            //set default values to filter combo-boxes and dateTimePickers and change dgv headers name
            ResetFilterBoxes();
            ChangeDgvHeaders();
        }

        #endregion

        #region databaseAndButtons

        //get data from database
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _threadUpdateResourcesUsage.Start();

            //raising SystemEvents_PowerModeChanged event at the begin of application
            SystemEvents_PowerModeChanged(this, null);

            //select * from database
            var errMsg = DataBaseManagement.SelectStm(_recordsList);

            if (errMsg != string.Empty)
                MessageBox.Show(errMsg, @"FrmMain_Load");
            else
                ResetDgv(_recordsList);
        }

        //inserting record when battery change by 1%
        private void InsertAtChange(object source, EventArgs e)
        {
            var threadInsertAtChange = new Thread(InsertAtChange)
            {
                Name = "threadInsertAtChange",
                Priority = ThreadPriority.AboveNormal
            };
            threadInsertAtChange.Start();
        }

        private void InsertAtChange()
        {
            var errMsg = string.Empty;

            string LocalInsertAtChange()
            {
                return DataBaseManagement.InsertStm(
                    _resourcesMonitor.BatteryPercent,
                    _resourcesMonitor.ChargerStatus, _resourcesMonitor.CpuMonitor(), _resourcesMonitor.RamMonitor(),
                    _resourcesMonitor.HdMonitor()
                );
            }

            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate { errMsg = LocalInsertAtChange(); }));
            else
                errMsg = LocalInsertAtChange();

            if (errMsg != string.Empty)
                MessageBox.Show(errMsg, @"InsertAtChange");
            else
            {
                //update Dgv
                DataBaseManagement.SelectStm(_recordsList);
                ResetDgv(_recordsList);
            }
        }

        //delete log record
        private void btnDelLog_Click(object sender, EventArgs e)
        {
            //there is no row to delete it
            if (_recordsList.Count == 0)
                return;

            var delIndex = Convert.ToInt32(txtIndex.Text);

            //check message before delete
            if (MessageBox.Show(@$"Are you sure that you want to delete record number: {delIndex} ?",
                @"Delete Confirmation",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            var errMsg = DataBaseManagement.DeleteStm(delIndex);

            if (errMsg != string.Empty)
                MessageBox.Show(errMsg, @"btnDelLog_Click");
            else
            {
                //update Dgv
                DataBaseManagement.SelectStm(_recordsList);
                ResetDgv(_recordsList);

                MessageBox.Show($@"Delete Record at index: {delIndex} was done successfully",
                    @"Process Completed Successfully");
            }
        }

        //filter records using dates
        private void btnFilter_Click(object sender, EventArgs e)
        {
            //build dates that user want to filter from and to
            var filterFrom = Convert.ToDateTime(
                dtpDateFrom.Value.Month + "/" + dtpDateFrom.Value.Day + "/" + dtpDateFrom.Value.Year + " " +
                cbxFromHour.Text + ":" + cbxFromMin.Text + ":" + cbxFromSec.Text + " " + cbxFromTT.Text
            );

            var filterTo = Convert.ToDateTime(
                dtpDateTo.Value.Month + "/" + dtpDateTo.Value.Day + "/" + dtpDateTo.Value.Year + " " +
                cbxToHour.Text + ":" + cbxToMin.Text + ":" + cbxToSec.Text + " " + cbxToTT.Text
            );

            //filterFrom date not equal to or greater than filterTo date or date after now
            if (DateTime.Compare(filterFrom, filterTo) is 0 or 1 ||
                DateTime.Compare(filterFrom, DateTime.Now) is 1 ||
                DateTime.Compare(filterTo, DateTime.Now) is 1)
                return;

            //linq statement filter data
            var dataFiltered = _recordsList.Where(record =>
                Convert.ToDateTime(string.Concat(record.Date, " ", record.Time)) >= filterFrom &&
                Convert.ToDateTime(string.Concat(record.Date, " ", record.Time)) <= filterTo);

            try
            {
                ResetDgv(dataFiltered);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, @"btnFilter_Click");
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var fromHours = Convert12To24HourSystem(Convert.ToInt32(cbxFromHour.Text), cbxFromTT.Text);
            var toHours = Convert12To24HourSystem(Convert.ToInt32(cbxToHour.Text), cbxToTT.Text);

            //build dates that user want to report from and to
            var startDate =
                @$"{dtpDateFrom.Value.Year}-{dtpDateFrom.Value.Month}-{dtpDateFrom.Value.Day} {fromHours}:{cbxFromMin.Text}:{cbxFromSec.Text}";

            var endDate =
                @$"{dtpDateTo.Value.Year}-{dtpDateTo.Value.Month}-{dtpDateTo.Value.Day} {toHours}:{cbxToMin.Text}:{cbxToSec.Text}";

            DataBaseManagement.SelectStm(_reportList, startDate, endDate);

            MessageBox.Show(_reportList.Aggregate(string.Empty, (current, item) => current + item.LagBatteryPercent));
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            ResetDgv(_recordsList);
            ResetFilterBoxes();
        }

        #endregion

        #region textboxes

        //fill text boxes according to user selection from Dgv at two events ( Dgv_RowEnter & Dgv_RowsRemoved )
        private void Dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            FillTextBoxes(Dgv.Rows[e.RowIndex]);
        }

        //fill textboxes according to row index passed
        private void FillTextBoxes(DataGridViewRow row)
        {
            void LocalFillTextBoxes()
            {
                try
                {
                    //clear text boxes when _recordsList has zero rows
                    if (_recordsList.Count == 0)
                    {
                        txtIndex.Clear();
                        txtDate.Clear();
                        txtTime.Clear();
                        txtBatteryPercentage.Clear();
                        txtChargerStatus.Clear();
                        txtCpuUtil.Clear();
                        txtRamUtil.Clear();
                        txtGpuUtil.Clear();
                        txtHdUtil.Clear();
                        return;
                    }

                    txtIndex.Text = row.Cells[0].Value.ToString();
                    txtDate.Text = row.Cells[1].Value.ToString();
                    txtTime.Text = row.Cells[2].Value.ToString();
                    txtBatteryPercentage.Text = row.Cells[3].Value.ToString();
                    txtChargerStatus.Text = row.Cells[4].Value.ToString();
                    txtCpuUtil.Text = row.Cells[5].Value + @" %";
                    txtRamUtil.Text = row.Cells[6].Value + @" %";
                    //txtGpuUtil.Text = row.Cells[].Value.ToString();
                    txtHdUtil.Text = row.Cells[7].Value + @" %";
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, @"FillTextBoxes");
                    ResetDgv(_recordsList);
                }
            }

            if (InvokeRequired)
                Invoke(new MethodInvoker(LocalFillTextBoxes));
            else
                LocalFillTextBoxes();
        }

        #endregion

        #region NotifyIcon

        //minimize form from btnMinimize button
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            void LocalBtnMinimizeClick()
            {
                Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip
                (
                    3000,
                    null,
                    @"Smart Battery Charger is still running Click here to activate.",
                    ToolTipIcon.Info
                );
            }

            if (InvokeRequired)
                Invoke(new MethodInvoker(LocalBtnMinimizeClick));
            else
                LocalBtnMinimizeClick();
        }

        //maximize form from
        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            void LocalNotifyIconBalloonTipClicked()
            {
                notifyIcon.Visible = false;
                Visible = true;
            }

            if (InvokeRequired)
                Invoke(new MethodInvoker(LocalNotifyIconBalloonTipClicked));
            else
                LocalNotifyIconBalloonTipClicked();

        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon_BalloonTipClicked(sender, e);
        }

        #endregion

        #region resourceUsage

        private void UpdateResourcesUsage()
        {
            tryAgain:
            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    var cpuTemp = _resourcesMonitor.CpuMonitor();
                    var ramTemp = _resourcesMonitor.RamMonitor();
                    var hdTemp = _resourcesMonitor.HdMonitor();

                    pbCpu.Value = cpuTemp;
                    lblCpuPercent.Text = cpuTemp + @" %";

                    pbRam.Value = ramTemp;
                    lblRamPercent.Text = ramTemp + @" %";

                    pbHD.Value = hdTemp;
                    lblHDPercent.Text = hdTemp + @" %";
                }));
            }

            //error in calculation from performance system
            catch (Exception err)
            {
                MessageBox.Show(err.Message, @"UpdateResourcesUsage");
            }

            finally
            {
                Thread.Sleep(1000);
            }

            goto tryAgain;
        }

        #endregion

        #region getInsertBatteryPercentage

        //get battery percentage
        private void GetBatteryPercentage(object source, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate { lblBatteryNow.Text = @$"{_resourcesMonitor.BatteryPercent} %"; }));
            else
                lblBatteryNow.Text = @$"{_resourcesMonitor.BatteryPercent} %";
        }

        //PowerModeChanged event
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            void LocalSystemEventsPowerModeChanged()
            {
                lblChargerNow.Text = _resourcesMonitor.ChargerStatus;

                //change lblChargerNow label according to charger status
                lblChargerNow.BackColor = lblChargerNow.Text == @"Online" ? Color.Chartreuse : Color.Red;
            }

            if (InvokeRequired)
                Invoke(new MethodInvoker(LocalSystemEventsPowerModeChanged));
            else
                LocalSystemEventsPowerModeChanged();
        }

        #endregion

        #region reset

        private void ResetFilterBoxes()
        {
            void LocalResetFilterBoxes()
            {
                //set default values to filter combo-boxes
                dtpDateFrom.Value = DateTime.Now.Date;
                cbxFromHour.SelectedIndex = cbxFromHour.FindString(@"12");
                cbxFromMin.SelectedIndex = cbxFromMin.FindString(@"00");
                cbxFromSec.SelectedIndex = cbxFromSec.FindString(@"00");
                cbxFromTT.SelectedIndex = cbxFromTT.FindString(@"AM");

                dtpDateTo.Value = DateTime.Now.Date;
                cbxToHour.SelectedIndex = cbxToHour.FindString(Convert24To12HourSystem(DateTime.Now.Hour).Value);
                cbxToMin.SelectedIndex = cbxToMin.FindString(DateTime.Now.Minute.ToString().Length == 1
                    ? @$"0+{DateTime.Now.Minute}"
                    : DateTime.Now.Minute.ToString());
                cbxToSec.SelectedIndex = cbxToSec.FindString(DateTime.Now.Second.ToString().Length == 1
                    ? @$"0+{DateTime.Now.Second}"
                    : DateTime.Now.Second.ToString());
                cbxToTT.SelectedIndex = cbxToTT.FindString(Convert24To12HourSystem(DateTime.Now.Hour).Key);
            }

            if (InvokeRequired)
                Invoke(new MethodInvoker(LocalResetFilterBoxes));
            else
                LocalResetFilterBoxes();
        }

        private void ResetDgv(List<RecordInfo> dataSource)
        {
            void LocalResetDgv()
            {
                ChangeDgvHeaders();
                _bindingSource.DataSource = dataSource;
                Dgv.DataSource = _bindingSource;
                _bindingSource.CurrencyManager.Refresh();
            }

            if (InvokeRequired)
                Invoke(new MethodInvoker(LocalResetDgv));
            else
                LocalResetDgv();
        }

        private void ResetDgv(IEnumerable<RecordInfo> dataSource)
        {
            void LocalResetDgv()
            {
                ChangeDgvHeaders();
                _bindingSource.DataSource = dataSource;
                Dgv.DataSource = _bindingSource;
                _bindingSource.CurrencyManager.Refresh();
            }

            if (InvokeRequired)
                Invoke(new MethodInvoker(LocalResetDgv));
            else
                LocalResetDgv();
        }

        private void ChangeDgvHeaders()
        {
            if (Dgv.Columns[@"BatteryPercent"] != null)
                Dgv.Columns[@"BatteryPercent"].HeaderText = @"Battery Percent";

            if (Dgv.Columns[@"ChargerStatus"] != null)
                Dgv.Columns[@"ChargerStatus"].HeaderText = @"Charger Status";

            if (Dgv.Columns[@"CpuUtilization"] != null)
                Dgv.Columns[@"CpuUtilization"].HeaderText = @"Processor Utilization";

            if (Dgv.Columns[@"RamUtilization"] != null)
                Dgv.Columns[@"RamUtilization"].HeaderText = @"RAM Utilization";

            if (Dgv.Columns[@"HdUtilization"] != null)
                Dgv.Columns[@"HdUtilization"].HeaderText = @"Hard Disk Utilization";
        }

        private KeyValuePair<string, string> Convert24To12HourSystem(int hoursIn24) =>
            hoursIn24 switch
            {
                0 => new KeyValuePair<string, string>(@"AM", "12"),
                1 => new KeyValuePair<string, string>(@"AM", "01"),
                2 => new KeyValuePair<string, string>(@"AM", "02"),
                3 => new KeyValuePair<string, string>(@"AM", "03"),
                4 => new KeyValuePair<string, string>(@"AM", "04"),
                5 => new KeyValuePair<string, string>(@"AM", "05"),
                6 => new KeyValuePair<string, string>(@"AM", "06"),
                7 => new KeyValuePair<string, string>(@"AM", "07"),
                8 => new KeyValuePair<string, string>(@"AM", "08"),
                9 => new KeyValuePair<string, string>(@"AM", "09"),
                10 => new KeyValuePair<string, string>(@"AM", hoursIn24.ToString()),
                11 => new KeyValuePair<string, string>(@"AM", hoursIn24.ToString()),
                12 => new KeyValuePair<string, string>(@"PM", "12"),
                _ => new KeyValuePair<string, string>(@"PM", (hoursIn24 - 12).ToString())
            };

        private string Convert12To24HourSystem(int hoursIn12, string tt) =>
            tt switch
            {
                @"AM" when hoursIn12 == 12 => "00",
                @"AM" when hoursIn12 == 1 => "01",
                @"AM" when hoursIn12 == 2 => "02",
                @"AM" when hoursIn12 == 3 => "03",
                @"AM" when hoursIn12 == 4 => "04",
                @"AM" when hoursIn12 == 5 => "05",
                @"AM" when hoursIn12 == 6 => "06",
                @"AM" when hoursIn12 == 7 => "07",
                @"AM" when hoursIn12 == 8 => "08",
                @"AM" when hoursIn12 == 9 => "09",
                @"AM" when hoursIn12 == 10 => "10",
                @"AM" when hoursIn12 == 11 => "11",

                @"PM" when hoursIn12 == 12 => "12",
                @"PM" when hoursIn12 == 1 => "13",
                @"PM" when hoursIn12 == 2 => "14",
                @"PM" when hoursIn12 == 3 => "15",
                @"PM" when hoursIn12 == 4 => "16",
                @"PM" when hoursIn12 == 5 => "17",
                @"PM" when hoursIn12 == 6 => "18",
                @"PM" when hoursIn12 == 7 => "19",
                @"PM" when hoursIn12 == 8 => "20",
                @"PM" when hoursIn12 == 9 => "21",
                @"PM" when hoursIn12 == 10 => "22",
                @"PM" when hoursIn12 == 11 => "23",
                _ => string.Empty
            };

        private string AddOneDigit(string str) => str.Length == 1 ? $"0 + {str}" : str;

        #endregion
    }
}