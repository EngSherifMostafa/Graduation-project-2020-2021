using System;
using System.Data;
using System.Windows.Forms;

namespace SmartBatteryCharger
{
    internal partial class FrmMain : Form
    {
        private DataTable _dataTbl;

        public FrmMain()
        {
            InitializeComponent();
        }

        //fill textboxes according to row index passed
        private void FillTextBoxes(int rowIndex)
        {
            txtIndex.Text = _dataTbl.Rows[rowIndex][0].ToString();
            txtDate.Text = DateTime.Parse(_dataTbl.Rows[rowIndex][1].ToString() ?? string.Empty).ToLongDateString();
            txtTime.Text = _dataTbl.Rows[rowIndex][2].ToString();
            txtBatteryPercentage.Text = _dataTbl.Rows[rowIndex][3].ToString();
            txtChargerStatus.Text = _dataTbl.Rows[rowIndex][4].ToString();
        }

        //get data from database
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _dataTbl = new DataTable();
            var retVal = DataBaseMngt.ExecSqlCmd(
                "Select colIndex as [Index], [colDate] as [Date], [colTime] as [Time], " +
                "[colBatteryStatus] as [Battery Status], [colChargerStatus] as [Charger Status] " +
                "from [tblLogFile]", _dataTbl);
            
            if (retVal != "Statement executed")
                MessageBox.Show(retVal);
            else
                Dgv.DataSource = _dataTbl;
        }

        //delete log record
        private void btnDelLog_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(@$"Are you sure that you want to delete record number:{txtIndex.Text} ?", @"Delete Confirmation",
                MessageBoxButtons.YesNo)) != DialogResult.Yes) return;
            
            var retVal = DataBaseMngt.ExecSqlCmd($"Delete from tblLogFile where colIndex = {txtIndex.Text}",
                _dataTbl);

            //update Dgv

            MessageBox.Show(retVal != "Statement executed" ? retVal : $@"Delete Record at index: {txtIndex.Text}",
                @"Process Completed Successfully");
        }

        //minimize form from btnMinimize button
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon.BalloonTipText = @"Smart Battery Charger App has been minimized";
            notifyIcon.BalloonTipTitle = @"Smart Battery Charger";
            notifyIcon.ShowBalloonTip(3000);
        }

        //maximize form from NotifyIcon
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            notifyIcon.Icon = null;
            notifyIcon.BalloonTipText = @"Smart Battery Charger App has Comeback";
            notifyIcon.BalloonTipTitle = @"Smart Battery Charger";
            notifyIcon.ShowBalloonTip(3000);
        }

        //fill text boxes according to user selection from Dgv
        private void Dgv_RowEnter(object sender, DataGridViewCellEventArgs e) => FillTextBoxes(e.RowIndex);
    }
}