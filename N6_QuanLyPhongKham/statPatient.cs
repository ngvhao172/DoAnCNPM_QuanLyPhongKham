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
    public partial class statPatient : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        public statPatient()
        {
            InitializeComponent();
        }
        private void loadAppfromto()
        {
            DataTable dt = ct.getAppfromto(dtpFrom.Text, dtpTo.Text);
            patientDataGridView.DataSource = dt;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadAppfromto();
        }
    }
}
