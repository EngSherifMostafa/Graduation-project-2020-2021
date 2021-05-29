using Microsoft.Win32;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Battery_Charger
{
    internal partial class FrmMain : Form
    {
        #region initializer
        //initialize data table to be data source for data grid view
        private DataTable _dataTbl = new();

        //initialize PowerStatus to provide info about battery and charger
        private readonly PowerStatus _batteryInfo = SystemInformation.PowerStatus;

        //initialize BatteryMonitor to provide streaming battery percentage
        private readonly BatteryMonitor _batteryMonitor = new();

        //constructor
        public FrmMain()
        {
            InitializeComponent();

            //get battery percent at initialization time
            lblBatteryNow.Text = (int)(_batteryInfo.BatteryLifePercent * 100) + @" %";

            //add SystemEvents_PowerModeChanged event using Microsoft.Win32 API
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            //add GetBatteryPercentage to PercentChanged event
            _batteryMonitor.PercentChanged += GetBatteryPercentage;
        }
        #endregion

        #region getBatteryPercentage
        //get battery percentage
        private void GetBatteryPercentage(object source, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {
                lblBatteryNow.Text = (int)(_batteryInfo.BatteryLifePercent * 100) + @" %";
            }));
        }

        //PowerModeChanged event
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            lblChargerNow.Text = _batteryInfo.PowerLineStatus.ToString();

            //change lblChargerNow label according to charger status
            lblChargerNow.BackColor = lblChargerNow.Text == @"Online" ? Color.Chartreuse : Color.Red;
        }
        #endregion

        #region dealWithTextboxes
        //fill text boxes according to user selection from Dgv at two events ( Dgv_RowEnter & Dgv_RowsRemoved )
        private void Dgv_RowEnter(object sender, DataGridViewCellEventArgs e) => FillTextBoxes(e.RowIndex);
        private void Dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) => FillTextBoxes(e.RowIndex);

        //fill textboxes according to row index passed
        private void FillTextBoxes(int rowIndex)
        {
            //clear text boxes when table has zero rows
            if (_dataTbl.Rows.Count == 0)
            {
                txtIndex.Clear();
                txtDate.Clear();
                txtTime.Clear();
                txtBatteryPercentage.Clear();
                txtChargerStatus.Clear();
                return;
            }

            txtIndex.Text = _dataTbl.Rows[rowIndex][0].ToString();
            txtDate.Text = DateTime.Parse(_dataTbl.Rows[rowIndex][1].ToString() ?? string.Empty)
                .ToString(format: "dd MMMM yyyy");
            txtTime.Text = _dataTbl.Rows[rowIndex][2].ToString();
            txtBatteryPercentage.Text = _dataTbl.Rows[rowIndex][3].ToString();
            txtChargerStatus.Text = _dataTbl.Rows[rowIndex][4].ToString();
        }

        #endregion

        #region dealWithDatabase
        //get data from database
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //raising SystemEvents_PowerModeChanged event at the begin of application
            SystemEvents_PowerModeChanged(this, null);
            //select * from database
            var errMsg = DataBaseMngt.SelectStm(ref _dataTbl);

            if (errMsg != null)
                MessageBox.Show(errMsg);

            else
                Dgv.DataSource = _dataTbl;
        }

        //delete log record
        private void btnDelLog_Click(object sender, EventArgs e)
        {
            //there is no row to delete it
            if (_dataTbl.Rows.Count == 0)
                return;

            var delIndex = int.Parse(txtIndex.Text);

            //check message before delete
            if ((MessageBox.Show(@$"Are you sure that you want to delete record number: {delIndex} ?", @"Delete Confirmation",
                MessageBoxButtons.YesNo)) != DialogResult.Yes) return;

            var errMsg = DataBaseMngt.DeleteStm(delIndex, ref _dataTbl);

            if (errMsg != null)
                MessageBox.Show(errMsg);
            else
            {
                //update Dgv
                DataBaseMngt.SelectStm(ref _dataTbl);

                MessageBox.Show($@"Delete Record at index: {delIndex} was done successfully", @"Process Completed Successfully");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var whereStm = @$"Where colDate between '{dtpFrom.Value:dd MMMM yyyy}' and '{dtpTo.Value:dd MMMM yyyy}'";

            //correct condition
            if (dtpFrom.Value < dtpTo.Value)
                DataBaseMngt.SelectStm(ref _dataTbl, whereStm);

            //error dates
            else
                DataBaseMngt.SelectStm(ref _dataTbl);
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
    }
}