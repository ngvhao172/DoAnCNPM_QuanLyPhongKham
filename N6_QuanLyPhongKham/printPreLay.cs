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
    public partial class printPreLay : Form
    {
        private Controller ct = new Controller();
        private string mahd;
        private string bacsi;
        private string benhnhan;
        private string mabenhnhan;
        private string sdt;
        private string ngaylap;
        public printPreLay()
        {
            InitializeComponent();
        }
        public printPreLay(string mahd, string bacsi, string benhnhan, string mabenhnhan, string sdt, string ngaylap)
        {
            InitializeComponent();
            this.mahd = mahd;
            this.bacsi = bacsi;
            this.benhnhan = benhnhan;
            this.mabenhnhan = mabenhnhan;
            this.sdt = sdt;
            this.ngaylap = ngaylap;
        }
        private void setValue()
        {
            txtID.Text = mahd;
            txtDocNam.Text = bacsi;
            txtPaName.Text = benhnhan;
            txtIDPa.Text = mabenhnhan;
            txtPN.Text = sdt;
            txtDate.Text = ngaylap;
        }
        private void printPreLay_Load(object sender, EventArgs e)
        {
            setValue();
            loadPreDetail();
        }
        private void loadPreDetail()
        {
            DataTable dataTable = ct.loadPreDetail(mahd);
            predeDataGridView.DataSource = dataTable;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;
        
        public void button1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = new PrintDocument();
            printPreviewDialog.Document.PrintPage += printDocument1_PrintPage;
            printPreviewDialog.ShowDialog();
        }
    }
}
