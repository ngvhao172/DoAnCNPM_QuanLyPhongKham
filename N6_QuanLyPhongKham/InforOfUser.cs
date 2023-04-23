using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N6_QuanLyPhongKham
{
    public partial class InforOfUser : DevExpress.XtraEditors.XtraUserControl
    {
        private Account acc = new Account();
        private Controller ct = new Controller();
        public void setAccVal(string acs, string psd)
        {
            acc.SDT = acs;
            acc.MatKhau = psd;
        }
        public InforOfUser()
        {
            InitializeComponent();
        }

        private void InforOfUser_Load(object sender, EventArgs e)
        {
            showInfo(acc);
            txtID.Enabled = false;
            btnSave.Enabled = false;
            txtRole.Enabled = false;
            txtPhoneNumber.Enabled = false;
        }
        public void disablefield(bool b)
        {
            txtFullName.Enabled = b;
            txtAddress.Enabled = b;
            txtDob.Enabled = b;
            txtPhoneNumber.Enabled = b;
            txtGender.Enabled = b;
        }
        private void showInfo(Account acc)
        {
            disablefield(false);
            User us = new User();
            string type = ct.ShowTypeAcc(acc);
            if (type.Trim() == "Bác sĩ")
                us = ct.ShowInfo(acc,"BacSi");
            else if (type.Trim() == "Bệnh nhân")
                us = ct.ShowInfo(acc, "BenhNhan");
            if (type.Trim() == "Nhân viên")
                us = ct.ShowInfo(acc, "NhanVien");
            if (type.Trim() == "Kế toán")
                us = ct.ShowInfo(acc, "KeToan");
            if (us != null)
            {
                txtID.Text = us.ID;
                txtFullName.Text = us.HoTen;
                txtGender.Text = us.GioiTinh;
                txtDob.Text = us.NgaySinh.ToString();
                txtAddress.Text = us.DiaChi;
                txtPhoneNumber.Text = us.SDT;
            }
            if (type != null)
            {
                txtRole.Text = type;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            disablefield(true);
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string hoTen = txtFullName.Text;
            string type = ct.ShowTypeAcc(acc);
            if (type.Trim() == "Bệnh nhân")
            {
                try
                {
                    ct.editUser("BenhNhan", txtID.Text, txtFullName.Text, txtPhoneNumber.Text, DateTime.Parse(txtDob.Text), txtGender.Text, "", "", txtAddress.Text, "");
                    MessageBox.Show("Thay đổi thông tin thành công");
                    disablefield(false);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
            }
            else if (type.Trim() == "Bác sĩ") {
                try
                {
                    ct.editEmployeeInfo("BacSi", txtID.Text, txtFullName.Text, txtPhoneNumber.Text, DateTime.Parse(txtDob.Text), txtGender.Text, "", "", txtAddress.Text, "");
                    MessageBox.Show("Thay đổi thông tin thành công");
                    disablefield(false);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
            }  
            else if (type.Trim() == "Nhân viên") {
                try
                {
                    ct.editEmployeeInfo("NhanVien", txtID.Text, txtFullName.Text, txtPhoneNumber.Text, DateTime.Parse(txtDob.Text), txtGender.Text, "", "", txtAddress.Text, "");
                    MessageBox.Show("Thay đổi thông tin thành công");
                    disablefield(false);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
            }   
            else if (type.Trim() == "Kế toán")
            {
                try
                {
                    ct.editEmployeeInfo("KeToan", txtID.Text, txtFullName.Text, txtPhoneNumber.Text, DateTime.Parse(txtDob.Text), txtGender.Text, "", "", txtAddress.Text, "");
                    MessageBox.Show("Thay đổi thông tin thành công");
                    disablefield(false);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
            }
            btnSave.Enabled = false;
            disablefield(false);
        }
    }
}
