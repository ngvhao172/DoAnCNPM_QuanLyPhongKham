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
    public partial class listPatientSearch : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        public listPatientSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
        public void loadPatient()
        {
            DataTable tb = ct.loadPatient();
            patientDataGridView.DataSource = tb;
        }

        private void listPatientSearch_Load(object sender, EventArgs e)
        {
            loadPatient();
        }
        public void loadPatientwithCondition()
        {
            DataTable tb = ct.loadPatientwithCondition(txtID.Text);
            patientDataGridView.DataSource = tb;
        }
        public void loadPatientwithCondition2()
        {
            DataTable tb = ct.loadPatientwithCondition2(txtFullName.Text);
            patientDataGridView.DataSource = tb;
        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                loadPatient();
            }
            else
            {
                loadPatientwithCondition();
            }
        }
        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            if (txtFullName.Text == "")
            {
                loadPatient();
            }
            else
            {
                loadPatientwithCondition2();
            }
        }
    }
}
