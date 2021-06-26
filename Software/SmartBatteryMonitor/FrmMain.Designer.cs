
namespace Smart_Battery_Monitor
{
    internal partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTransactionsCount = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbHD = new System.Windows.Forms.ProgressBar();
            this.pbRam = new System.Windows.Forms.ProgressBar();
            this.pbGpu = new System.Windows.Forms.ProgressBar();
            this.pbCpu = new System.Windows.Forms.ProgressBar();
            this.lblBatteryNow = new System.Windows.Forms.Label();
            this.lblChargerNow = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHDPercent = new System.Windows.Forms.Label();
            this.lblGpuPercent = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblRamPercent = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCpuPercent = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.cbxToSec = new System.Windows.Forms.ComboBox();
            this.cbxFromSec = new System.Windows.Forms.ComboBox();
            this.cbxToTT = new System.Windows.Forms.ComboBox();
            this.cbxToMin = new System.Windows.Forms.ComboBox();
            this.cbxToHour = new System.Windows.Forms.ComboBox();
            this.cbxFromHour = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cbxFromTT = new System.Windows.Forms.ComboBox();
            this.cbxFromMin = new System.Windows.Forms.ComboBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDelRecord = new System.Windows.Forms.Button();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.pnlTb = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChargerStatus = new System.Windows.Forms.TextBox();
            this.txtCpuUtil = new System.Windows.Forms.TextBox();
            this.txtHdUtil = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtRamUtil = new System.Windows.Forms.TextBox();
            this.txtBatteryPercentage = new System.Windows.Forms.TextBox();
            this.txtGpuUtil = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.pnlTb.SuspendLayout();
            this.SuspendLayout();
            // 
            // Index
            // 
            this.Index.HeaderText = "Index";
            this.Index.MinimumWidth = 6;
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Width = 125;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 125;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 125;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1343, 778);
            this.tabControl1.TabIndex = 45;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tabPage1.Controls.Add(this.lblTransactionsCount);
            this.tabPage1.Controls.Add(this.btnReport);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.btnMinimize);
            this.tabPage1.Controls.Add(this.pnlFilter);
            this.tabPage1.Controls.Add(this.btnDelRecord);
            this.tabPage1.Controls.Add(this.Dgv);
            this.tabPage1.Controls.Add(this.pnlTb);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1335, 737);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Battery Monitor";
            // 
            // lblTransactionsCount
            // 
            this.lblTransactionsCount.AutoSize = true;
            this.lblTransactionsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTransactionsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblTransactionsCount.Location = new System.Drawing.Point(495, 674);
            this.lblTransactionsCount.Name = "lblTransactionsCount";
            this.lblTransactionsCount.Size = new System.Drawing.Size(140, 31);
            this.lblTransactionsCount.TabIndex = 46;
            this.lblTransactionsCount.Text = "transactions";
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.Teal;
            this.btnReport.Location = new System.Drawing.Point(662, 654);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(168, 72);
            this.btnReport.TabIndex = 45;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pbHD);
            this.panel1.Controls.Add(this.pbRam);
            this.panel1.Controls.Add(this.pbGpu);
            this.panel1.Controls.Add(this.pbCpu);
            this.panel1.Controls.Add(this.lblBatteryNow);
            this.panel1.Controls.Add(this.lblChargerNow);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblHDPercent);
            this.panel1.Controls.Add(this.lblGpuPercent);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblRamPercent);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lblCpuPercent);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(6, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 200);
            this.panel1.TabIndex = 43;
            // 
            // pbHD
            // 
            this.pbHD.Location = new System.Drawing.Point(118, 105);
            this.pbHD.Name = "pbHD";
            this.pbHD.Size = new System.Drawing.Size(234, 23);
            this.pbHD.TabIndex = 22;
            // 
            // pbRam
            // 
            this.pbRam.Location = new System.Drawing.Point(118, 76);
            this.pbRam.Name = "pbRam";
            this.pbRam.Size = new System.Drawing.Size(234, 23);
            this.pbRam.TabIndex = 21;
            // 
            // pbGpu
            // 
            this.pbGpu.Location = new System.Drawing.Point(118, 47);
            this.pbGpu.Name = "pbGpu";
            this.pbGpu.Size = new System.Drawing.Size(234, 23);
            this.pbGpu.TabIndex = 20;
            // 
            // pbCpu
            // 
            this.pbCpu.Location = new System.Drawing.Point(118, 19);
            this.pbCpu.Name = "pbCpu";
            this.pbCpu.Size = new System.Drawing.Size(234, 23);
            this.pbCpu.TabIndex = 19;
            // 
            // lblBatteryNow
            // 
            this.lblBatteryNow.AutoSize = true;
            this.lblBatteryNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblBatteryNow.Location = new System.Drawing.Point(207, 165);
            this.lblBatteryNow.Name = "lblBatteryNow";
            this.lblBatteryNow.Size = new System.Drawing.Size(32, 23);
            this.lblBatteryNow.TabIndex = 24;
            this.lblBatteryNow.Text = "bp";
            // 
            // lblChargerNow
            // 
            this.lblChargerNow.AutoSize = true;
            this.lblChargerNow.Location = new System.Drawing.Point(207, 136);
            this.lblChargerNow.Name = "lblChargerNow";
            this.lblChargerNow.Size = new System.Drawing.Size(25, 23);
            this.lblChargerNow.TabIndex = 23;
            this.lblChargerNow.Text = "cs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 23);
            this.label7.TabIndex = 40;
            this.label7.Text = "Battery Percentage";
            // 
            // lblHDPercent
            // 
            this.lblHDPercent.AutoSize = true;
            this.lblHDPercent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHDPercent.Location = new System.Drawing.Point(358, 105);
            this.lblHDPercent.Name = "lblHDPercent";
            this.lblHDPercent.Size = new System.Drawing.Size(61, 23);
            this.lblHDPercent.TabIndex = 38;
            this.lblHDPercent.Text = "HDPer";
            // 
            // lblGpuPercent
            // 
            this.lblGpuPercent.AutoSize = true;
            this.lblGpuPercent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGpuPercent.Location = new System.Drawing.Point(358, 47);
            this.lblGpuPercent.Name = "lblGpuPercent";
            this.lblGpuPercent.Size = new System.Drawing.Size(68, 23);
            this.lblGpuPercent.TabIndex = 36;
            this.lblGpuPercent.Text = "GpuPer";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(7, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 23);
            this.label14.TabIndex = 34;
            this.label14.Text = "Hard Disk";
            // 
            // lblRamPercent
            // 
            this.lblRamPercent.AutoSize = true;
            this.lblRamPercent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRamPercent.Location = new System.Drawing.Point(358, 76);
            this.lblRamPercent.Name = "lblRamPercent";
            this.lblRamPercent.Size = new System.Drawing.Size(71, 23);
            this.lblRamPercent.TabIndex = 37;
            this.lblRamPercent.Text = "RamPer";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(7, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 23);
            this.label13.TabIndex = 32;
            this.label13.Text = "GPU";
            // 
            // lblCpuPercent
            // 
            this.lblCpuPercent.AutoSize = true;
            this.lblCpuPercent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCpuPercent.Location = new System.Drawing.Point(358, 19);
            this.lblCpuPercent.Name = "lblCpuPercent";
            this.lblCpuPercent.Size = new System.Drawing.Size(67, 23);
            this.lblCpuPercent.TabIndex = 35;
            this.lblCpuPercent.Text = "CpuPer";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(7, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 23);
            this.label12.TabIndex = 33;
            this.label12.Text = "RAM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(7, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 23);
            this.label11.TabIndex = 31;
            this.label11.Text = "CPU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 23);
            this.label6.TabIndex = 39;
            this.label6.Text = "Charger Status";
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMinimize.Location = new System.Drawing.Point(1140, 654);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(168, 72);
            this.btnMinimize.TabIndex = 22;
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlFilter.Controls.Add(this.btnClearFilter);
            this.pnlFilter.Controls.Add(this.cbxToSec);
            this.pnlFilter.Controls.Add(this.cbxFromSec);
            this.pnlFilter.Controls.Add(this.cbxToTT);
            this.pnlFilter.Controls.Add(this.cbxToMin);
            this.pnlFilter.Controls.Add(this.cbxToHour);
            this.pnlFilter.Controls.Add(this.cbxFromHour);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.cbxFromTT);
            this.pnlFilter.Controls.Add(this.cbxFromMin);
            this.pnlFilter.Controls.Add(this.dtpDateTo);
            this.pnlFilter.Controls.Add(this.dtpDateFrom);
            this.pnlFilter.Controls.Add(this.label10);
            this.pnlFilter.Location = new System.Drawing.Point(6, 345);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(456, 180);
            this.pnlFilter.TabIndex = 42;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClearFilter.Location = new System.Drawing.Point(67, 127);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(144, 45);
            this.btnClearFilter.TabIndex = 20;
            this.btnClearFilter.Text = "Clear";
            this.btnClearFilter.UseVisualStyleBackColor = false;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // cbxToSec
            // 
            this.cbxToSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToSec.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxToSec.FormattingEnabled = true;
            this.cbxToSec.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cbxToSec.Location = new System.Drawing.Point(305, 88);
            this.cbxToSec.Name = "cbxToSec";
            this.cbxToSec.Size = new System.Drawing.Size(68, 29);
            this.cbxToSec.TabIndex = 17;
            // 
            // cbxFromSec
            // 
            this.cbxFromSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFromSec.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxFromSec.FormattingEnabled = true;
            this.cbxFromSec.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cbxFromSec.Location = new System.Drawing.Point(305, 38);
            this.cbxFromSec.Name = "cbxFromSec";
            this.cbxFromSec.Size = new System.Drawing.Size(68, 29);
            this.cbxFromSec.TabIndex = 12;
            // 
            // cbxToTT
            // 
            this.cbxToTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToTT.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxToTT.FormattingEnabled = true;
            this.cbxToTT.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cbxToTT.Location = new System.Drawing.Point(379, 88);
            this.cbxToTT.Name = "cbxToTT";
            this.cbxToTT.Size = new System.Drawing.Size(68, 29);
            this.cbxToTT.TabIndex = 18;
            // 
            // cbxToMin
            // 
            this.cbxToMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToMin.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxToMin.FormattingEnabled = true;
            this.cbxToMin.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cbxToMin.Location = new System.Drawing.Point(231, 88);
            this.cbxToMin.Name = "cbxToMin";
            this.cbxToMin.Size = new System.Drawing.Size(68, 29);
            this.cbxToMin.TabIndex = 16;
            // 
            // cbxToHour
            // 
            this.cbxToHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToHour.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxToHour.FormattingEnabled = true;
            this.cbxToHour.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbxToHour.Location = new System.Drawing.Point(158, 88);
            this.cbxToHour.Name = "cbxToHour";
            this.cbxToHour.Size = new System.Drawing.Size(68, 29);
            this.cbxToHour.TabIndex = 15;
            // 
            // cbxFromHour
            // 
            this.cbxFromHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFromHour.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxFromHour.FormattingEnabled = true;
            this.cbxFromHour.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbxFromHour.Location = new System.Drawing.Point(157, 38);
            this.cbxFromHour.Name = "cbxFromHour";
            this.cbxFromHour.Size = new System.Drawing.Size(68, 29);
            this.cbxFromHour.TabIndex = 10;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFilter.Location = new System.Drawing.Point(229, 126);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(144, 44);
            this.btnFilter.TabIndex = 19;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cbxFromTT
            // 
            this.cbxFromTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFromTT.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxFromTT.FormattingEnabled = true;
            this.cbxFromTT.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cbxFromTT.Location = new System.Drawing.Point(379, 38);
            this.cbxFromTT.Name = "cbxFromTT";
            this.cbxFromTT.Size = new System.Drawing.Size(68, 29);
            this.cbxFromTT.TabIndex = 13;
            // 
            // cbxFromMin
            // 
            this.cbxFromMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFromMin.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxFromMin.FormattingEnabled = true;
            this.cbxFromMin.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cbxFromMin.Location = new System.Drawing.Point(231, 38);
            this.cbxFromMin.Name = "cbxFromMin";
            this.cbxFromMin.Size = new System.Drawing.Size(68, 29);
            this.cbxFromMin.TabIndex = 11;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpDateTo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(5, 88);
            this.dtpDateTo.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(147, 28);
            this.dtpDateTo.TabIndex = 14;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpDateFrom.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(5, 38);
            this.dtpDateFrom.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(147, 28);
            this.dtpDateFrom.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(113, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(247, 24);
            this.label10.TabIndex = 30;
            this.label10.Text = "Filter By Date and Time";
            // 
            // btnDelRecord
            // 
            this.btnDelRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelRecord.Location = new System.Drawing.Point(901, 654);
            this.btnDelRecord.Name = "btnDelRecord";
            this.btnDelRecord.Size = new System.Drawing.Size(168, 72);
            this.btnDelRecord.TabIndex = 21;
            this.btnDelRecord.Text = "Delete Record";
            this.btnDelRecord.UseVisualStyleBackColor = false;
            this.btnDelRecord.Click += new System.EventHandler(this.btnDelRecord_Click);
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.Location = new System.Drawing.Point(468, 6);
            this.Dgv.MultiSelect = false;
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Dgv.RowTemplate.Height = 29;
            this.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(861, 642);
            this.Dgv.TabIndex = 44;
            this.Dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_RowEnter);
            // 
            // pnlTb
            // 
            this.pnlTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlTb.Controls.Add(this.label16);
            this.pnlTb.Controls.Add(this.label5);
            this.pnlTb.Controls.Add(this.label15);
            this.pnlTb.Controls.Add(this.label4);
            this.pnlTb.Controls.Add(this.label9);
            this.pnlTb.Controls.Add(this.label2);
            this.pnlTb.Controls.Add(this.label8);
            this.pnlTb.Controls.Add(this.label3);
            this.pnlTb.Controls.Add(this.label1);
            this.pnlTb.Controls.Add(this.txtChargerStatus);
            this.pnlTb.Controls.Add(this.txtCpuUtil);
            this.pnlTb.Controls.Add(this.txtHdUtil);
            this.pnlTb.Controls.Add(this.txtIndex);
            this.pnlTb.Controls.Add(this.txtRamUtil);
            this.pnlTb.Controls.Add(this.txtBatteryPercentage);
            this.pnlTb.Controls.Add(this.txtGpuUtil);
            this.pnlTb.Controls.Add(this.txtDate);
            this.pnlTb.Controls.Add(this.txtTime);
            this.pnlTb.Location = new System.Drawing.Point(6, 6);
            this.pnlTb.Name = "pnlTb";
            this.pnlTb.Size = new System.Drawing.Size(456, 333);
            this.pnlTb.TabIndex = 41;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(7, 293);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(188, 22);
            this.label16.TabIndex = 28;
            this.label16.Text = "HardDisk Utilization";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(7, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 22);
            this.label5.TabIndex = 29;
            this.label5.Text = "Charger Status";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(7, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(146, 22);
            this.label15.TabIndex = 26;
            this.label15.Text = "Ram Utilization";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(7, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 22);
            this.label4.TabIndex = 28;
            this.label4.Text = "Battery Percentage";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(7, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 22);
            this.label9.TabIndex = 27;
            this.label9.Text = "GPU Utilization";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(7, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 22);
            this.label8.TabIndex = 25;
            this.label8.Text = "Cpu Utilization";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(7, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 22);
            this.label3.TabIndex = 27;
            this.label3.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 22);
            this.label1.TabIndex = 25;
            this.label1.Text = "Index";
            // 
            // txtChargerStatus
            // 
            this.txtChargerStatus.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtChargerStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtChargerStatus.Location = new System.Drawing.Point(203, 153);
            this.txtChargerStatus.Name = "txtChargerStatus";
            this.txtChargerStatus.ReadOnly = true;
            this.txtChargerStatus.Size = new System.Drawing.Size(244, 29);
            this.txtChargerStatus.TabIndex = 4;
            this.txtChargerStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCpuUtil
            // 
            this.txtCpuUtil.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCpuUtil.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCpuUtil.Location = new System.Drawing.Point(203, 188);
            this.txtCpuUtil.Name = "txtCpuUtil";
            this.txtCpuUtil.ReadOnly = true;
            this.txtCpuUtil.Size = new System.Drawing.Size(244, 29);
            this.txtCpuUtil.TabIndex = 5;
            this.txtCpuUtil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHdUtil
            // 
            this.txtHdUtil.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHdUtil.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHdUtil.Location = new System.Drawing.Point(203, 293);
            this.txtHdUtil.Name = "txtHdUtil";
            this.txtHdUtil.ReadOnly = true;
            this.txtHdUtil.Size = new System.Drawing.Size(244, 29);
            this.txtHdUtil.TabIndex = 8;
            this.txtHdUtil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIndex
            // 
            this.txtIndex.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtIndex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIndex.Location = new System.Drawing.Point(203, 13);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.ReadOnly = true;
            this.txtIndex.Size = new System.Drawing.Size(244, 29);
            this.txtIndex.TabIndex = 0;
            this.txtIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRamUtil
            // 
            this.txtRamUtil.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtRamUtil.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRamUtil.Location = new System.Drawing.Point(203, 223);
            this.txtRamUtil.Name = "txtRamUtil";
            this.txtRamUtil.ReadOnly = true;
            this.txtRamUtil.Size = new System.Drawing.Size(244, 29);
            this.txtRamUtil.TabIndex = 6;
            this.txtRamUtil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBatteryPercentage
            // 
            this.txtBatteryPercentage.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBatteryPercentage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBatteryPercentage.Location = new System.Drawing.Point(203, 118);
            this.txtBatteryPercentage.Name = "txtBatteryPercentage";
            this.txtBatteryPercentage.ReadOnly = true;
            this.txtBatteryPercentage.Size = new System.Drawing.Size(244, 29);
            this.txtBatteryPercentage.TabIndex = 3;
            this.txtBatteryPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGpuUtil
            // 
            this.txtGpuUtil.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtGpuUtil.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGpuUtil.Location = new System.Drawing.Point(203, 258);
            this.txtGpuUtil.Name = "txtGpuUtil";
            this.txtGpuUtil.ReadOnly = true;
            this.txtGpuUtil.Size = new System.Drawing.Size(244, 29);
            this.txtGpuUtil.TabIndex = 7;
            this.txtGpuUtil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.Location = new System.Drawing.Point(203, 48);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(244, 29);
            this.txtDate.TabIndex = 1;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTime.Location = new System.Drawing.Point(203, 83);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(244, 29);
            this.txtTime.TabIndex = 2;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1367, 798);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart Battery Monitor";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.pnlTb.ResumeLayout(false);
            this.pnlTb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDelRecord;
        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Panel pnlTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChargerStatus;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.TextBox txtBatteryPercentage;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar pbHD;
        private System.Windows.Forms.ProgressBar pbRam;
        private System.Windows.Forms.ProgressBar pbGpu;
        private System.Windows.Forms.ProgressBar pbCpu;
        private System.Windows.Forms.Label lblBatteryNow;
        private System.Windows.Forms.Label lblChargerNow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHDPercent;
        private System.Windows.Forms.Label lblGpuPercent;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblRamPercent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCpuPercent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxFromHour;
        private System.Windows.Forms.ComboBox cbxToMin;
        private System.Windows.Forms.ComboBox cbxFromMin;
        private System.Windows.Forms.ComboBox cbxToHour;
        private System.Windows.Forms.ComboBox cbxToTT;
        private System.Windows.Forms.ComboBox cbxFromTT;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ComboBox cbxToSec;
        private System.Windows.Forms.ComboBox cbxFromSec;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCpuUtil;
        private System.Windows.Forms.TextBox txtHdUtil;
        private System.Windows.Forms.TextBox txtRamUtil;
        private System.Windows.Forms.TextBox txtGpuUtil;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblTransactionsCount;
    }
}

