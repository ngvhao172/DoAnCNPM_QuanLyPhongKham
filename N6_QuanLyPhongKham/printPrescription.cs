using System.Data;


namespace N6_QuanLyPhongKham
{
    public partial class printPrescription : DevExpress.XtraEditors.XtraUserControl
    {
        private string maDonThuoc;
        private string bacSi;
        private string tenBenhNhan;
        private string maBenhNhan;
        private string sdt;
        private string ngayKeDon;
        private Controller ct = new Controller();
        public printPrescription()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string from = dtpFrom.Text;
            string to = dtpTo.Text;
            DataTable dt = ct.loadPrescription(from,to);
            preDataGridView.DataSource = dt;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maDonThuoc)) {
                this.Hide();
                printPreLay ppl = new printPreLay(maDonThuoc, bacSi, tenBenhNhan, maBenhNhan, sdt, ngayKeDon);
                ppl.ShowDialog();
                


                //
            }
        }

        private void preDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Chỉ xử lý khi người dùng chọn một hàng
            {
                DataGridViewRow row = this.preDataGridView.Rows[e.RowIndex];
                maDonThuoc = row.Cells["MaDonThuoc"].Value.ToString();
                bacSi = row.Cells["BacSi"].Value.ToString();
                maBenhNhan = row.Cells["MaBenhNhan"].Value.ToString();
                tenBenhNhan = row.Cells["BenhNhan"].Value.ToString();
                sdt = row.Cells["SDT"].Value.ToString();
                ngayKeDon = row.Cells["NgayKeDon"].Value.ToString();
                // Xử lý các giá trị tùy theo nhu cầu của bạn
            }
        }

    }
}
