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
    public partial class historyApp : DevExpress.XtraEditors.XtraUserControl
    {
        private Account acc = new Account();
        private Controller ct = new Controller();
        public historyApp()
        {
            InitializeComponent();
        }
        public void setAccVal(string acs, string psd)
        {
            acc.SDT = acs;
            acc.MatKhau = psd;
        }
        private void historyApp_Load(object sender, EventArgs e)
        {
            loadhistoryApp();
        }
        private void loadhistoryApp()
        {
            User us = new User();
            us = ct.ShowInfo(acc, "BenhNhan");
            DataTable dt = ct.loadHistoryApp(us.ID);
            historyappDataGridView.DataSource = dt;
        }
    }
}
