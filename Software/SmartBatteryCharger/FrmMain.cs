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

        //initialize BindingSource to Refresh Dgv.DataSource
        private readonly BindingSource _bindingSource;

        //initialize data table to be data source for data grid view
        private readonly List<RecordInfo> _recordsList;
        private readonly ResourcesMonitor _resourcesMonitor;

        //constructor
        public FrmMain()
        {
            InitializeComponent();

            _bindingSource = new BindingSource();

            _recordsList = new List<RecordInfo>();

            _resourcesMonitor = new ResourcesMonitor();

            //get battery percent at initialization time
            lblBatteryNow.Text = @$"{_resourcesMonitor.BatteryPercent} %";

            //enable thread that responsible for update machine info part
            var threadUpdateResourcesUsage = new Thread(UpdateResourcesUsage)
                {Name = "threadUpdateResourcesUsage", IsBackground = true, Priority = ThreadPriority.Lowest};
            threadUpdateResourcesUsage.Start();

            //add SystemEvents_PowerModeChanged event using Microsoft.Win32 API
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            //add GetBatteryPercentage to PercentChanged event
            _resourcesMonitor.BatteryMonitor.PercentChanged += GetBatteryPercentage;

            //add InsertAtChange to PercentChanged event
            _resourcesMonitor.BatteryMonitor.PercentChanged += InsertAtChange;

            //set default values to filter combo-boxes
            cbxFromHour.SelectedIndex = 11;
            cbxFromMin.SelectedIndex = 0;
            cbxFromTT.SelectedIndex = 0;
            cbxToHour.SelectedIndex = 10;
            cbxToMin.SelectedIndex = 59;
            cbxToTT.SelectedIndex = 1;
        }

        #endregion

        #region database

        //get data from database
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //raising SystemEvents_PowerModeChanged event at the begin of application
            SystemEvents_PowerModeChanged(this, null);
            //select * from database
            var errMsg = DataBaseManagement.SelectStm(_recordsList);

            if (errMsg != string.Empty)
                MessageBox.Show(errMsg);

            else
            {
                _bindingSource.DataSource = _recordsList;
                Dgv.DataSource = _bindingSource;
            }

        }

        //inserting record when battery change by 1%
        private void InsertAtChange(object source, EventArgs e)
        {
            var errMsg = DataBaseManagement.InsertStm(_resourcesMonitor.BatteryPercent, _resourcesMonitor.ChargerStatus,
                _resourcesMonitor.CpuMonitor, _resourcesMonitor.RamMonitor, _resourcesMonitor.HdMonitor);

            if (errMsg != string.Empty)
                MessageBox.Show(errMsg);
            else
            {
                //update Dgv
                DataBaseManagement.SelectStm(_recordsList);
                Invoke(new Action(_bindingSource.CurrencyManager.Refresh));
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
            if ((MessageBox.Show(@$"Are you sure that you want to delete record number: {delIndex} ?",
                @"Delete Confirmation",
                MessageBoxButtons.YesNo)) != DialogResult.Yes) return;

            var errMsg = DataBaseManagement.DeleteStm(delIndex);

            if (errMsg != string.Empty)
                MessageBox.Show(errMsg);
            else
            {
                //update Dgv
                DataBaseManagement.SelectStm(_recordsList);
                Invoke(new Action(_bindingSource.CurrencyManager.Refresh));

                MessageBox.Show($@"Delete Record at index: {delIndex} was done successfully",
                    @"Process Completed Successfully");
            }
        }

        //filter records using dates
        private void btnFilter_Click(object sender, EventArgs e)
        {
            //build dates that user want to filter from and to
            var filterFrom = Convert.ToDateTime(dtpDateFrom.Value.Month + "/" + dtpDateFrom.Value.Day + "/" +
                                                dtpDateFrom.Value.Year + " " + cbxFromHour.Text + ":" +
                                                cbxFromMin.Text +
                                                ":" + "00" + " " + cbxFromTT.Text);
            var filterTo = Convert.ToDateTime(dtpDateTo.Value.Month + "/" + dtpDateTo.Value.Day + "/" +
                                              dtpDateTo.Value.Year + " " + cbxToHour.Text + ":" + cbxToMin.Text + ":" +
                                              "00" + " " + cbxToTT.Text);
            //linq statement filter data
            var dateFiltered = _recordsList.Where(record =>
                Convert.ToDateTime(string.Concat(record.Date, " ", record.Time)) >= filterFrom &&
                Convert.ToDateTime(string.Concat(record.Date, " ", record.Time)) <= filterTo);

            try
            {
                Dgv.DataSource = null;
                _bindingSource.DataSource = dateFiltered;
                Dgv.DataSource = _bindingSource;
                Invoke(new Action(_bindingSource.CurrencyManager.Refresh));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                // ignored
            }
        }

        #endregion

        #region textboxes

        //fill text boxes according to user selection from Dgv at two events ( Dgv_RowEnter & Dgv_RowsRemoved )
        private void Dgv_RowEnter(object sender, DataGridViewCellEventArgs e) =>
            Invoke(new Action<int>(FillTextBoxes), e.RowIndex);

        //fill textboxes according to row index passed
        private void FillTextBoxes(int rowIndex)
        {
            //clear text boxes when table has zero rows
            if (_recordsList.Count == 0)
            {
                txtIndex.Clear();
                txtDate.Clear();
                txtTime.Clear();
                txtBatteryPercentage.Clear();
                txtChargerStatus.Clear();
                return;
            }

            txtIndex.Text = _recordsList[rowIndex].Index.ToString();
            txtDate.Text = _recordsList[rowIndex].Date;
            txtTime.Text = _recordsList[rowIndex].Time;
            txtBatteryPercentage.Text = _recordsList[rowIndex].BatteryPercent.ToString();
            txtChargerStatus.Text = _recordsList[rowIndex].ChargerStatus;
        }

        #endregion

        #region NotifyIcon

        //minimize form from btnMinimize button
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon.ShowBalloonTip(
                3000,
                null,
                @"Smart Battery Charger is still running Click here to activate.",
                ToolTipIcon.Info
            );
        }

        //maximize form from 
        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e) => Visible = true;
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) => Visible = true;

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
            catch (Exception)
            {
                // ignored
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
        private void GetBatteryPercentage(object source, EventArgs e) =>
            Invoke(new MethodInvoker(delegate
            {
                lblBatteryNow.Text = @$"{_resourcesMonitor.BatteryPercent} %";
            }));

        //PowerModeChanged event
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            lblChargerNow.Text = _resourcesMonitor.ChargerStatus;

            //change lblChargerNow label according to charger status
            lblChargerNow.BackColor = lblChargerNow.Text == @"Online" ? Color.Chartreuse : Color.Red;
        }

        #endregion
    }
}