using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N6_QuanLyPhongKham
{
    public partial class ReceiptLayout : Form
    {
        private string madonthuoc;
        private Account acc = new Account();
        private Controller ct = new Controller();
        public void setAccVal(string acs, string psd)
        {
            acc.SDT = acs;
            acc.MatKhau = psd;
        }
        public ReceiptLayout()
        {
            InitializeComponent();
        }
        public ReceiptLayout(string madonthuoc)
        {
            InitializeComponent();
            this.madonthuoc = madonthuoc;
        }
        private void getInfo(string madonthuoc)
        {
            txtTenNhanVien.Text = ct.ShowInfo(acc,"NhanVien").HoTen;
            txtTenBenhNhan.Text = ct.getName(madonthuoc);
            txtNgayLap.Text = ct.getInforOfReceipt(madonthuoc).ngayLap.ToString();
            txtMaHoaDon.Text = ct.getInforOfReceipt(madonthuoc).maHoaDon.ToString();
            txtBill.Text = ct.getInforOfReceipt(madonthuoc).tongTien.ToString();
        }  
        public void loadSer()
        {
            DataTable dt = ct.getInforOfSer(madonthuoc);
            serviceDataGridView.DataSource = dt;
        }
        public void loadPres()
        {
            DataTable dt = ct.loadPreDetail(madonthuoc);
            medicinDataGridView.DataSource = dt;
        }


        private void ReceiptLayout_Load(object sender, EventArgs e)
        {
            getInfo(madonthuoc);
            loadSer();
            loadPres();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = new PrintDocument();
            printPreviewDialog.Document.PrintPage += printDocument1_PrintPage;
            printPreviewDialog.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;
    }
}
