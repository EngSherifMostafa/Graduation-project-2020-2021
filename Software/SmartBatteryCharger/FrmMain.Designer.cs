
namespace Smart_Battery_Charger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pbHD = new System.Windows.Forms.ProgressBar();
            this.pbRam = new System.Windows.Forms.ProgressBar();
            this.pbGpu = new System.Windows.Forms.ProgressBar();
            this.pbCpu = new System.Windows.Forms.ProgressBar();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.btnDelLog = new System.Windows.Forms.Button();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.pnlTb = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChargerStatus = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtBatteryPercentage = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.timerUpdateUsage = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.pnlTb.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
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
            this.tabControl1.Size = new System.Drawing.Size(1755, 518);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pbHD);
            this.tabPage1.Controls.Add(this.pbRam);
            this.tabPage1.Controls.Add(this.pbGpu);
            this.tabPage1.Controls.Add(this.pbCpu);
            this.tabPage1.Controls.Add(this.btnMinimize);
            this.tabPage1.Controls.Add(this.pnlFilter);
            this.tabPage1.Controls.Add(this.lblBatteryNow);
            this.tabPage1.Controls.Add(this.lblChargerNow);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.lblHDPercent);
            this.tabPage1.Controls.Add(this.lblGpuPercent);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.lblRamPercent);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.lblCpuPercent);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btnDelLog);
            this.tabPage1.Controls.Add(this.Dgv);
            this.tabPage1.Controls.Add(this.pnlTb);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1747, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Battery Monitor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pbHD
            // 
            this.pbHD.Location = new System.Drawing.Point(1374, 192);
            this.pbHD.Name = "pbHD";
            this.pbHD.Size = new System.Drawing.Size(261, 37);
            this.pbHD.TabIndex = 16;
            // 
            // pbRam
            // 
            this.pbRam.Location = new System.Drawing.Point(1374, 149);
            this.pbRam.Name = "pbRam";
            this.pbRam.Size = new System.Drawing.Size(261, 37);
            this.pbRam.TabIndex = 16;
            // 
            // pbGpu
            // 
            this.pbGpu.Location = new System.Drawing.Point(1374, 107);
            this.pbGpu.Name = "pbGpu";
            this.pbGpu.Size = new System.Drawing.Size(261, 37);
            this.pbGpu.TabIndex = 16;
            // 
            // pbCpu
            // 
            this.pbCpu.Location = new System.Drawing.Point(1374, 63);
            this.pbCpu.Name = "pbCpu";
            this.pbCpu.Size = new System.Drawing.Size(261, 37);
            this.pbCpu.TabIndex = 16;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMinimize.Location = new System.Drawing.Point(1077, 377);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(168, 72);
            this.btnMinimize.TabIndex = 15;
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.dtpTo);
            this.pnlFilter.Controls.Add(this.dtpFrom);
            this.pnlFilter.Controls.Add(this.label10);
            this.pnlFilter.Controls.Add(this.label8);
            this.pnlFilter.Controls.Add(this.label9);
            this.pnlFilter.Location = new System.Drawing.Point(3, 238);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(483, 211);
            this.pnlFilter.TabIndex = 14;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFilter.Location = new System.Drawing.Point(147, 139);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(171, 62);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpTo.Location = new System.Drawing.Point(99, 96);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(357, 34);
            this.dtpTo.TabIndex = 5;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpFrom.Location = new System.Drawing.Point(99, 56);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(357, 34);
            this.dtpFrom.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(147, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 28);
            this.label10.TabIndex = 3;
            this.label10.Text = "Filter By Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(23, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 31);
            this.label8.TabIndex = 3;
            this.label8.Text = "From:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(23, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 31);
            this.label9.TabIndex = 4;
            this.label9.Text = "To:";
            // 
            // lblBatteryNow
            // 
            this.lblBatteryNow.AutoSize = true;
            this.lblBatteryNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblBatteryNow.Location = new System.Drawing.Point(1463, 300);
            this.lblBatteryNow.Name = "lblBatteryNow";
            this.lblBatteryNow.Size = new System.Drawing.Size(36, 28);
            this.lblBatteryNow.TabIndex = 12;
            this.lblBatteryNow.Text = "bp";
            // 
            // lblChargerNow
            // 
            this.lblChargerNow.AutoSize = true;
            this.lblChargerNow.Location = new System.Drawing.Point(1463, 256);
            this.lblChargerNow.Name = "lblChargerNow";
            this.lblChargerNow.Size = new System.Drawing.Size(31, 28);
            this.lblChargerNow.TabIndex = 13;
            this.lblChargerNow.Text = "cs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1263, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 28);
            this.label7.TabIndex = 10;
            this.label7.Text = "Battery Percentage";
            // 
            // lblHDPercent
            // 
            this.lblHDPercent.AutoSize = true;
            this.lblHDPercent.Location = new System.Drawing.Point(1639, 192);
            this.lblHDPercent.Name = "lblHDPercent";
            this.lblHDPercent.Size = new System.Drawing.Size(72, 28);
            this.lblHDPercent.TabIndex = 11;
            this.lblHDPercent.Text = "HDPer";
            // 
            // lblGpuPercent
            // 
            this.lblGpuPercent.AutoSize = true;
            this.lblGpuPercent.Location = new System.Drawing.Point(1639, 107);
            this.lblGpuPercent.Name = "lblGpuPercent";
            this.lblGpuPercent.Size = new System.Drawing.Size(80, 28);
            this.lblGpuPercent.TabIndex = 11;
            this.lblGpuPercent.Text = "GpuPer";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1263, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 28);
            this.label14.TabIndex = 11;
            this.label14.Text = "Hard Disk";
            // 
            // lblRamPercent
            // 
            this.lblRamPercent.AutoSize = true;
            this.lblRamPercent.Location = new System.Drawing.Point(1639, 149);
            this.lblRamPercent.Name = "lblRamPercent";
            this.lblRamPercent.Size = new System.Drawing.Size(84, 28);
            this.lblRamPercent.TabIndex = 11;
            this.lblRamPercent.Text = "RamPer";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1263, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 28);
            this.label13.TabIndex = 11;
            this.label13.Text = "GPU";
            // 
            // lblCpuPercent
            // 
            this.lblCpuPercent.AutoSize = true;
            this.lblCpuPercent.Location = new System.Drawing.Point(1639, 63);
            this.lblCpuPercent.Name = "lblCpuPercent";
            this.lblCpuPercent.Size = new System.Drawing.Size(78, 28);
            this.lblCpuPercent.TabIndex = 11;
            this.lblCpuPercent.Text = "CpuPer";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1263, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 28);
            this.label12.TabIndex = 11;
            this.label12.Text = "RAM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1263, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 28);
            this.label11.TabIndex = 11;
            this.label11.Text = "CPU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1263, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Charger Status";
            // 
            // btnDelLog
            // 
            this.btnDelLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelLog.Location = new System.Drawing.Point(747, 377);
            this.btnDelLog.Name = "btnDelLog";
            this.btnDelLog.Size = new System.Drawing.Size(168, 72);
            this.btnDelLog.TabIndex = 9;
            this.btnDelLog.Text = "Delete Log";
            this.btnDelLog.UseVisualStyleBackColor = false;
            this.btnDelLog.Click += new System.EventHandler(this.btnDelLog_Click);
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
            this.Dgv.Location = new System.Drawing.Point(489, 30);
            this.Dgv.MultiSelect = false;
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Dgv.RowTemplate.Height = 29;
            this.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(756, 338);
            this.Dgv.TabIndex = 8;
            this.Dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_RowEnter);
            // 
            // pnlTb
            // 
            this.pnlTb.Controls.Add(this.label5);
            this.pnlTb.Controls.Add(this.label4);
            this.pnlTb.Controls.Add(this.label2);
            this.pnlTb.Controls.Add(this.label3);
            this.pnlTb.Controls.Add(this.label1);
            this.pnlTb.Controls.Add(this.txtChargerStatus);
            this.pnlTb.Controls.Add(this.txtIndex);
            this.pnlTb.Controls.Add(this.txtBatteryPercentage);
            this.pnlTb.Controls.Add(this.txtDate);
            this.pnlTb.Controls.Add(this.txtTime);
            this.pnlTb.Location = new System.Drawing.Point(3, 30);
            this.pnlTb.Name = "pnlTb";
            this.pnlTb.Size = new System.Drawing.Size(483, 202);
            this.pnlTb.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(14, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Charger Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(14, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Battery Percentage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Index";
            // 
            // txtChargerStatus
            // 
            this.txtChargerStatus.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtChargerStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtChargerStatus.Location = new System.Drawing.Point(234, 153);
            this.txtChargerStatus.Name = "txtChargerStatus";
            this.txtChargerStatus.ReadOnly = true;
            this.txtChargerStatus.Size = new System.Drawing.Size(226, 29);
            this.txtChargerStatus.TabIndex = 0;
            this.txtChargerStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIndex
            // 
            this.txtIndex.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtIndex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIndex.Location = new System.Drawing.Point(234, 13);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.ReadOnly = true;
            this.txtIndex.Size = new System.Drawing.Size(226, 29);
            this.txtIndex.TabIndex = 0;
            this.txtIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBatteryPercentage
            // 
            this.txtBatteryPercentage.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBatteryPercentage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBatteryPercentage.Location = new System.Drawing.Point(234, 118);
            this.txtBatteryPercentage.Name = "txtBatteryPercentage";
            this.txtBatteryPercentage.ReadOnly = true;
            this.txtBatteryPercentage.Size = new System.Drawing.Size(226, 29);
            this.txtBatteryPercentage.TabIndex = 0;
            this.txtBatteryPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.Location = new System.Drawing.Point(234, 48);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(226, 29);
            this.txtDate.TabIndex = 0;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTime.Location = new System.Drawing.Point(234, 83);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(226, 29);
            this.txtTime.TabIndex = 0;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerUpdateUsage
            // 
            this.timerUpdateUsage.Interval = 1000;
            this.timerUpdateUsage.Tick += new System.EventHandler(this.timerUpdateUsage_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1779, 544);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart Battery Charger";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.pnlTb.ResumeLayout(false);
            this.pnlTb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblBatteryNow;
        private System.Windows.Forms.Label lblChargerNow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelLog;
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
        private System.Windows.Forms.Timer timerUpdateUsage;
        private System.Windows.Forms.ProgressBar pbHD;
        private System.Windows.Forms.ProgressBar pbRam;
        private System.Windows.Forms.ProgressBar pbGpu;
        private System.Windows.Forms.ProgressBar pbCpu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblHDPercent;
        private System.Windows.Forms.Label lblGpuPercent;
        private System.Windows.Forms.Label lblRamPercent;
        private System.Windows.Forms.Label lblCpuPercent;
    }
}

