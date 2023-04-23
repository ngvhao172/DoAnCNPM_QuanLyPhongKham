using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N6_QuanLyPhongKham
{
    public partial class prescriptionList : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        private string madonthuoc;
        public prescriptionList()
        {
            InitializeComponent();
        }
        public void setMadonthuoc(string madonthuoc)
        {
            this.madonthuoc = madonthuoc;
            txtPreID.Text = madonthuoc; // hiển thị giá trị madonthuoc trên textbox
        }
        private bool checkvalid()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg_noti.Text = "Bạn chưa nhập tên thuốc";
                msg_noti.Show();
                txtName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                msg_noti.Text = "Bạn chưa nhập số lượng";
                msg_noti.Show();
                txtQuantity.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtDosage.Text))
            {
                msg_noti.Text = "Bạn chưa nhập số lượng";
                msg_noti.Show();
                txtDosage.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtFrequency.Text))
            {
                msg_noti.Text = "Bạn chưa nhập số lượng";
                msg_noti.Show();
                txtFrequency.Focus();
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string idDonThuoc = madonthuoc;
            string tenThuoc = txtName.Text;
            string lieuLuong = txtDosage.Text;
            string soLuong = txtQuantity.Text;
            string tuanSuat = txtFrequency.Text;
            string giaTien = "";
            if (checkvalid())
            {
                try
                {
                    ct.addPrescriptionDetail(idDonThuoc,tenThuoc,lieuLuong,soLuong,tuanSuat,giaTien);
                    MessageBox.Show("Đã thêm thành công");
                    loadPrescriptionDetail();
                    clearField();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
            }
        }
        private void loadPrescriptionDetail()
        {
            DataTable dt = ct.loadPreDetail(txtPreID.Text);
            prescriptionDataGridView.DataSource= dt;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }

        private void prescriptionList_Load(object sender, EventArgs e)
        {
            msg_noti.Hide();
            txtPreID.Enabled= false;
            loadPrescriptionDetail();
        }
        private void clearField()
        {
            txtName.Text = "";
            txtDosage.Text = "";
            txtFrequency.Text = "";
            txtQuantity.Text = "";
        }
    }
}
