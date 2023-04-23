namespace N6_QuanLyPhongKham
{
    partial class historyApp
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
            this.historyappDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.historyappDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // historyappDataGridView
            // 
            this.historyappDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.historyappDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyappDataGridView.Location = new System.Drawing.Point(15, 19);
            this.historyappDataGridView.Name = "historyappDataGridView";
            this.historyappDataGridView.RowTemplate.Height = 25;
            this.historyappDataGridView.Size = new System.Drawing.Size(1028, 552);
            this.historyappDataGridView.TabIndex = 0;
            // 
            // historyApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.historyappDataGridView);
            this.Name = "historyApp";
            this.Size = new System.Drawing.Size(1068, 677);
            this.Load += new System.EventHandler(this.historyApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.historyappDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView historyappDataGridView;
    }
}
