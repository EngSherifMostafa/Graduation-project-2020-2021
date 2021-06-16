using System;
using System.Linq;
using System.Drawing;
using Microsoft.Win32;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Smart_Battery_Charger
{
    internal partial class FrmMain : Form
    {
        #region initializer

        //declare list of class RecordInfo to be data source for data grid view
        private readonly List<RecordInfo> _recordsList;

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
            _resourcesMonitor = new ResourcesMonitor();

            //get battery percent at initialization time
            lblBatteryNow.Text = @$"{_resourcesMonitor.BatteryPercent} %";

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

            //set default values to filter combo-boxes and dateTimePickers
            ResetFilterBoxes();
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
                    _resourcesMonitor.ChargerStatus, _resourcesMonitor.CpuMonitor, _resourcesMonitor.RamMonitor,
                    _resourcesMonitor.HdMonitor
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

            if (DateTime.Compare(filterFrom, filterTo) is 0 or 1) return;
            //linq statement filter data
            var dateFiltered = _recordsList.Where(record =>
                Convert.ToDateTime(string.Concat(record.Date, " ", record.Time)) >= filterFrom &&
                Convert.ToDateTime(string.Concat(record.Date, " ", record.Time)) <= filterTo);

            try
            {
                ResetDgv(dateFiltered);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, @"btnFilter_Click");
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            ResetDgv(_recordsList);
            ResetFilterBoxes();
        }

        #endregion

        #region textboxes

        //fill text boxes according to user selection from Dgv at two events ( Dgv_RowEnter & Dgv_RowsRemoved )
        private void Dgv_RowEnter(object sender, DataGridViewCellEventArgs e) => FillTextBoxes(Dgv.Rows[e.RowIndex]);

        //fill textboxes according to row index passed
        private void FillTextBoxes(DataGridViewRow row)
        {
            void LocalFillTextBoxes()
            {
                try
                {
                    //clear text boxes when table has zero rows
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

                    if(row == null) return;
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

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) =>
            notifyIcon_BalloonTipClicked(sender, e);

        #endregion

        #region resourceUsage

        private void UpdateResourcesUsage()
        {
            tryAgain:
            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    pbCpu.Value = _resourcesMonitor.CpuMonitor;
                    lblCpuPercent.Text = pbCpu.Value + @" %";

                    pbRam.Value = _resourcesMonitor.RamMonitor;
                    lblRamPercent.Text = pbRam.Value + @" %";

                    pbHD.Value = _resourcesMonitor.HdMonitor;
                    lblHDPercent.Text = pbHD.Value + @" %";
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
                cbxFromHour.SelectedIndex = 11;
                cbxFromMin.SelectedIndex = 0;
                cbxFromSec.SelectedIndex = 0;
                cbxFromTT.SelectedIndex = 0;

                dtpDateTo.Value = DateTime.Now.Date;
                cbxToHour.SelectedIndex = 10;
                cbxToMin.SelectedIndex = 59;
                cbxToSec.SelectedIndex = 59;
                cbxToTT.SelectedIndex = 1;
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
                _bindingSource.DataSource = dataSource;
                Dgv.DataSource = _bindingSource;
                _bindingSource.CurrencyManager.Refresh();
            }

            if (InvokeRequired)
                Invoke(new MethodInvoker(LocalResetDgv));
            else
                LocalResetDgv();
        }

        #endregion
    }
}