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
    public partial class listDoctorSearch : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        public listDoctorSearch()
        {
            InitializeComponent();
        }

        private void listDoctorSearch_Load(object sender, EventArgs e)
        {
            loadDoctor();
        }
        private void loadDoctor()
        {
            DataTable dt = ct.loadDoctor();
            doctorDataGridView.DataSource = dt;
        }
        private void loadDoctor2()
        {
            DataTable dt = ct.loadDoctorwithCondition(txtID.Text);
            doctorDataGridView.DataSource = dt;
        }
        private void loadDoctor3()
        {
            DataTable dt = ct.loadDoctorwithCondition2(txtFullName.Text);
            doctorDataGridView.DataSource = dt;
        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                loadDoctor();
            }
            else
            {
                loadDoctor2();
            }
            
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            if(txtFullName.Text == "")
            {
                loadDoctor();
            }
            else
            {
                loadDoctor3();
            }
            
        }
    }
}
