namespace N6_QuanLyPhongKham
{
    partial class InforOfAcc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InforOfAcc));
            this.grbInforofAcc = new System.Windows.Forms.GroupBox();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.textEdit10 = new DevExpress.XtraEditors.TextEdit();
            this.grbInforofAcc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit10.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grbInforofAcc
            // 
            this.grbInforofAcc.Controls.Add(this.pictureEdit2);
            this.grbInforofAcc.Controls.Add(this.label10);
            this.grbInforofAcc.Controls.Add(this.textEdit10);
            this.grbInforofAcc.Location = new System.Drawing.Point(3, 3);
            this.grbInforofAcc.Name = "grbInforofAcc";
            this.grbInforofAcc.Size = new System.Drawing.Size(854, 533);
            this.grbInforofAcc.TabIndex = 12;
            this.grbInforofAcc.TabStop = false;
            this.grbInforofAcc.Text = "Thông tin tài khoản";
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.Location = new System.Drawing.Point(29, 32);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Properties.ZoomPercent = 200D;
            this.pictureEdit2.Size = new System.Drawing.Size(100, 96);
            this.pictureEdit2.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(159, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Tài khoản";
            // 
            // textEdit10
            // 
            this.textEdit10.Location = new System.Drawing.Point(235, 46);
            this.textEdit10.Name = "textEdit10";
            this.textEdit10.Size = new System.Drawing.Size(234, 20);
            this.textEdit10.TabIndex = 0;
            // 
            // InforOfAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbInforofAcc);
            this.Name = "InforOfAcc";
            this.Size = new System.Drawing.Size(800, 568);
            this.grbInforofAcc.ResumeLayout(false);
            this.grbInforofAcc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit10.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grbInforofAcc;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private Label label10;
        private DevExpress.XtraEditors.TextEdit textEdit10;
    }
}
