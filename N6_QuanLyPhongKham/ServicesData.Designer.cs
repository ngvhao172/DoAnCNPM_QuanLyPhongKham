namespace N6_QuanLyPhongKham
{
    partial class ServicesData
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.msg_noti = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCan = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.specialtyDataGridView = new System.Windows.Forms.GroupBox();
            this.serviceDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFal = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.specialtyDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbFal);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.msg_noti);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnCan);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtServiceName);
            this.groupBox2.Controls.Add(this.txtID);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1061, 165);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // msg_noti
            // 
            this.msg_noti.AutoSize = true;
            this.msg_noti.ForeColor = System.Drawing.Color.Red;
            this.msg_noti.Location = new System.Drawing.Point(101, 85);
            this.msg_noti.Name = "msg_noti";
            this.msg_noti.Size = new System.Drawing.Size(26, 13);
            this.msg_noti.TabIndex = 22;
            this.msg_noti.Text = "msg";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(786, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 38);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCan
            // 
            this.btnCan.Location = new System.Drawing.Point(957, 112);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(75, 38);
            this.btnCan.TabIndex = 19;
            this.btnCan.Text = "Hủy";
            this.btnCan.UseVisualStyleBackColor = true;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(319, 112);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 38);
            this.btnDel.TabIndex = 18;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(548, 112);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 38);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tên dịch vụ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã dịch vụ";
            // 
            // txtServiceName
            // 
            this.txtServiceName.Location = new System.Drawing.Point(369, 38);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(165, 21);
            this.txtServiceName.TabIndex = 5;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(101, 38);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(165, 21);
            this.txtID.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(101, 112);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 38);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // specialtyDataGridView
            // 
            this.specialtyDataGridView.Controls.Add(this.serviceDataGridView);
            this.specialtyDataGridView.Location = new System.Drawing.Point(6, 182);
            this.specialtyDataGridView.Name = "specialtyDataGridView";
            this.specialtyDataGridView.Size = new System.Drawing.Size(1061, 444);
            this.specialtyDataGridView.TabIndex = 6;
            this.specialtyDataGridView.TabStop = false;
            this.specialtyDataGridView.Text = "Danh sách khoa";
            // 
            // serviceDataGridView
            // 
            this.serviceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.serviceDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.serviceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceDataGridView.Location = new System.Drawing.Point(20, 29);
            this.serviceDataGridView.Name = "serviceDataGridView";
            this.serviceDataGridView.RowHeadersWidth = 51;
            this.serviceDataGridView.RowTemplate.Height = 25;
            this.serviceDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.serviceDataGridView.Size = new System.Drawing.Size(1012, 388);
            this.serviceDataGridView.TabIndex = 0;
            this.serviceDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.patientDataGridView_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(564, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Giá dịch vụ";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(632, 38);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(165, 21);
            this.txtPrice.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(825, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Mã khoa";
            // 
            // cmbFal
            // 
            this.cmbFal.FormattingEnabled = true;
            this.cmbFal.Location = new System.Drawing.Point(888, 38);
            this.cmbFal.Name = "cmbFal";
            this.cmbFal.Size = new System.Drawing.Size(121, 21);
            this.cmbFal.TabIndex = 27;
            // 
            // ServicesData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.specialtyDataGridView);
            this.Name = "ServicesData";
            this.Size = new System.Drawing.Size(1109, 632);
            this.Load += new System.EventHandler(this.ServicesData_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.specialtyDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox2;
        private Label msg_noti;
        private Button btnSave;
        private Button btnCan;
        private Button btnDel;
        private Button btnEdit;
        private Label label3;
        private Label label1;
        private TextBox txtServiceName;
        private TextBox txtID;
        private Button btnAdd;
        private GroupBox specialtyDataGridView;
        private DataGridView serviceDataGridView;
        private ComboBox cmbFal;
        private Label label4;
        private Label label2;
        private TextBox txtPrice;
    }
}
