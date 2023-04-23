using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N6_QuanLyPhongKham
{
    public partial class statService : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        public statService()
        {
            InitializeComponent();
        }

        private void statService_Load(object sender, EventArgs e)
        {

        }
        private void loadServicefromto()
        {
            DataTable dt = ct.getSerfromto(dtpFrom.Text,dtpTo.Text);
            serviceDataGridView.DataSource = dt;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadServicefromto();
        }
    }
}
