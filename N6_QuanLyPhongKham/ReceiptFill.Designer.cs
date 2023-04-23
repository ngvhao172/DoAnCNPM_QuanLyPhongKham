namespace N6_QuanLyPhongKham
{
    partial class ReceiptFill
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptFill));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPreID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.msg_noti = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.prescripDataGridView = new System.Windows.Forms.GroupBox();
            this.prescriptionDataGridView = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnGetReceipt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.prescripDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prescriptionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(972, 289);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đơn thuốc";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(249, 227);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(81, 33);
            this.btnDel.TabIndex = 19;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(411, 227);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(81, 33);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPreID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.msg_noti);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(39, 35);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(879, 162);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đơn thuốc";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(491, 75);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(218, 21);
            this.txtPrice.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Giá tiền";
            // 
            // txtPreID
            // 
            this.txtPreID.Location = new System.Drawing.Point(180, 32);
            this.txtPreID.Name = "txtPreID";
            this.txtPreID.Size = new System.Drawing.Size(218, 21);
            this.txtPreID.TabIndex = 36;
            this.txtPreID.TextChanged += new System.EventHandler(this.txtPreID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Mã đơn thuốc";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(180, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 21);
            this.txtName.TabIndex = 31;
            // 
            // msg_noti
            // 
            this.msg_noti.AutoSize = true;
            this.msg_noti.ForeColor = System.Drawing.Color.Red;
            this.msg_noti.Location = new System.Drawing.Point(180, 119);
            this.msg_noti.Name = "msg_noti";
            this.msg_noti.Size = new System.Drawing.Size(50, 13);
            this.msg_noti.TabIndex = 30;
            this.msg_noti.Text = "msg_noti";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tên thuốc";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(73, 227);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 33);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // prescripDataGridView
            // 
            this.prescripDataGridView.Controls.Add(this.prescriptionDataGridView);
            this.prescripDataGridView.Location = new System.Drawing.Point(3, 305);
            this.prescripDataGridView.Name = "prescripDataGridView";
            this.prescripDataGridView.Size = new System.Drawing.Size(972, 421);
            this.prescripDataGridView.TabIndex = 5;
            this.prescripDataGridView.TabStop = false;
            this.prescripDataGridView.Text = "Danh sách đơn thuốc";
            // 
            // prescriptionDataGridView
            // 
            this.prescriptionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prescriptionDataGridView.Location = new System.Drawing.Point(21, 20);
            this.prescriptionDataGridView.Name = "prescriptionDataGridView";
            this.prescriptionDataGridView.RowTemplate.Height = 25;
            this.prescriptionDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.prescriptionDataGridView.Size = new System.Drawing.Size(932, 370);
            this.prescriptionDataGridView.TabIndex = 0;
            this.prescriptionDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.prescriptionDataGridView_CellContentClick);
            // 
            // btnGetReceipt
            // 
            this.btnGetReceipt.Location = new System.Drawing.Point(24, 757);
            this.btnGetReceipt.Name = "btnGetReceipt";
            this.btnGetReceipt.Size = new System.Drawing.Size(107, 34);
            this.btnGetReceipt.TabIndex = 6;
            this.btnGetReceipt.Text = "Xuất hóa đơn";
            this.btnGetReceipt.UseVisualStyleBackColor = true;
            this.btnGetReceipt.Click += new System.EventHandler(this.btnGetReceipt_Click);
            // 
            // ReceiptFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGetReceipt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.prescripDataGridView);
            this.Name = "ReceiptFill";
            this.Size = new System.Drawing.Size(985, 838);
            this.Load += new System.EventHandler(this.Receipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.prescripDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prescriptionDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BindingSource bindingSource1;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDialog printDialog1;
        private GroupBox groupBox1;
        private Button btnDel;
        private Button btnRefresh;
        private GroupBox groupBox2;
        private TextBox txtPrice;
        private Label label1;
        private TextBox txtPreID;
        private Label label4;
        private TextBox txtName;
        private Label msg_noti;
        private Label label3;
        private Button btnAdd;
        private GroupBox prescripDataGridView;
        private DataGridView prescriptionDataGridView;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button btnGetReceipt;
    }
}
