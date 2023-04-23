namespace N6_QuanLyPhongKham
{
    partial class AppointmentSer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCan = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.msg_noti = new System.Windows.Forms.Label();
            this.teAppTime = new DevExpress.XtraEditors.TimeEdit();
            this.cmbSer = new System.Windows.Forms.ComboBox();
            this.cmbDoc = new System.Windows.Forms.ComboBox();
            this.cmbFal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpAppDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.appDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teAppTime.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCan);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(972, 383);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng ký lịch hẹn";
            // 
            // btnCan
            // 
            this.btnCan.Location = new System.Drawing.Point(356, 329);
            this.btnCan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(81, 33);
            this.btnCan.TabIndex = 19;
            this.btnCan.Text = "Hủy lịch hẹn";
            this.btnCan.UseVisualStyleBackColor = true;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(222, 329);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(81, 33);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.msg_noti);
            this.groupBox2.Controls.Add(this.teAppTime);
            this.groupBox2.Controls.Add(this.cmbSer);
            this.groupBox2.Controls.Add(this.cmbDoc);
            this.groupBox2.Controls.Add(this.cmbFal);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMota);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpAppDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(39, 46);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(879, 254);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đăng ký";
            // 
            // msg_noti
            // 
            this.msg_noti.AutoSize = true;
            this.msg_noti.ForeColor = System.Drawing.Color.Red;
            this.msg_noti.Location = new System.Drawing.Point(183, 146);
            this.msg_noti.Name = "msg_noti";
            this.msg_noti.Size = new System.Drawing.Size(50, 13);
            this.msg_noti.TabIndex = 30;
            this.msg_noti.Text = "msg_noti";
            // 
            // teAppTime
            // 
            this.teAppTime.EditValue = new System.DateTime(2023, 3, 25, 0, 0, 0, 0);
            this.teAppTime.Location = new System.Drawing.Point(594, 67);
            this.teAppTime.Name = "teAppTime";
            this.teAppTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.teAppTime.Size = new System.Drawing.Size(215, 20);
            this.teAppTime.TabIndex = 29;
            this.teAppTime.Validating += new System.ComponentModel.CancelEventHandler(this.teAppTime_Validating);
            // 
            // cmbSer
            // 
            this.cmbSer.FormattingEnabled = true;
            this.cmbSer.Items.AddRange(new object[] {
            "Khác"});
            this.cmbSer.Location = new System.Drawing.Point(594, 26);
            this.cmbSer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSer.Name = "cmbSer";
            this.cmbSer.Size = new System.Drawing.Size(215, 21);
            this.cmbSer.TabIndex = 28;
            // 
            // cmbDoc
            // 
            this.cmbDoc.FormattingEnabled = true;
            this.cmbDoc.Location = new System.Drawing.Point(183, 112);
            this.cmbDoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDoc.Name = "cmbDoc";
            this.cmbDoc.Size = new System.Drawing.Size(215, 21);
            this.cmbDoc.TabIndex = 27;
            // 
            // cmbFal
            // 
            this.cmbFal.FormattingEnabled = true;
            this.cmbFal.Location = new System.Drawing.Point(183, 26);
            this.cmbFal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFal.Name = "cmbFal";
            this.cmbFal.Size = new System.Drawing.Size(215, 21);
            this.cmbFal.TabIndex = 26;
            this.cmbFal.SelectedIndexChanged += new System.EventHandler(this.cmbFal_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Mô tả (tùy chọn)";
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(594, 115);
            this.txtMota.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(215, 103);
            this.txtMota.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Giờ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Bác sĩ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Khoa";
            // 
            // dtpAppDate
            // 
            this.dtpAppDate.CustomFormat = "MM/dd/yyyy";
            this.dtpAppDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppDate.Location = new System.Drawing.Point(183, 70);
            this.dtpAppDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpAppDate.Name = "dtpAppDate";
            this.dtpAppDate.Size = new System.Drawing.Size(215, 21);
            this.dtpAppDate.TabIndex = 19;
            this.dtpAppDate.ValueChanged += new System.EventHandler(this.dtpAppDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ngày khám";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tên dịch vụ";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(73, 329);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(81, 33);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.appDataGridView);
            this.groupBox3.Location = new System.Drawing.Point(3, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(972, 337);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lịch khám đã đăng ký";
            // 
            // appDataGridView
            // 
            this.appDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appDataGridView.Location = new System.Drawing.Point(21, 20);
            this.appDataGridView.Name = "appDataGridView";
            this.appDataGridView.RowTemplate.Height = 25;
            this.appDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appDataGridView.Size = new System.Drawing.Size(932, 300);
            this.appDataGridView.TabIndex = 0;
            // 
            // AppointmentSer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "AppointmentSer";
            this.Size = new System.Drawing.Size(1064, 730);
            this.Load += new System.EventHandler(this.AppointmentSer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teAppTime.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button btnRegister;
        private GroupBox groupBox2;
        private ComboBox cmbSer;
        private ComboBox cmbDoc;
        private ComboBox cmbFal;
        private Label label6;
        private TextBox txtMota;
        private Label label5;
        private Label label4;
        private Label label3;
        private DateTimePicker dtpAppDate;
        private Label label2;
        private Label label1;
        private DevExpress.XtraEditors.TimeEdit teAppTime;
        private Button btnRefresh;
        private GroupBox groupBox3;
        private DataGridView appDataGridView;
        private Button btnCan;
        private Label msg_noti;
    }
}
