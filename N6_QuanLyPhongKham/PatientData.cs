using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N6_QuanLyPhongKham
{
    public partial class PatientData : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        private int dk;
        public PatientData()
        {
            InitializeComponent();
            msg_noti.Hide();
        }
        public void loadPatient()
        {
            DataTable tb = ct.loadPatient();
            patientDataGridView.DataSource = tb;
        }

        private void PatientData_Load(object sender, EventArgs e)
        {
            loadPatient();
            cmbGender.SelectedIndex = 0;
            txtID.Enabled = false;
            disable(false);
            btnSave.Enabled = false;
            btnCan.Enabled = false;
        }
        private bool isValidAccount(string account)
        {
            try
            {
                Regex rx = new Regex(@"^(0)([0-9]*)$");
                if (rx.IsMatch(account))
                    if (account.Length >= 10 && account.Length <= 11)
                    {
                        return true;
                    }
            }
            catch (FormatException)
            {
                return false;
            }
            return false;
        }
        private bool checkvalid()
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                msg_noti.Text = "Họ tên không được để trống";
                msg_noti.Show();
                txtFullName.Focus();
                return false;
            }
            /*  else if (string.IsNullOrEmpty(txtEmail.Text))
              {
                  msg_noti.Text = "Email không được để trống";
                  msg_noti.Show();
                  txtFullName.Focus();
                  return false;

              }*/
            else if (string.IsNullOrEmpty(cmbGender.Text))
            {
                msg_noti.Text = "Giới tính không được để trống";
                msg_noti.Show();
                txtFullName.Focus();
                return false;

            }
            else if (string.IsNullOrEmpty(txtAccount.Text))
            {
                msg_noti.Text = "Số điện thoại không được để trống";
                msg_noti.Show();
                txtFullName.Focus();
                return false;
            }
            else
            {/*
                if (IsValidEmail(txtEmail.Text) == false)
                {
                    msg_noti.Text = "Email không đúng định dạng";
                    msg_noti.Show();
                    txtAccount.Focus();
                    return false;
                }
                else*/
                if (isValidAccount(txtAccount.Text) == false)
                {
                    msg_noti.Text = "Số điện thoại phải bắt đầu bằng số 0 và chứa 10 hoặc 11 số";
                    msg_noti.Show();
                    txtAccount.Focus();
                    return false;
                }
            }
            msg_noti.Hide();
            return true;
        }
        private void clearfield()
        {
            txtID.Clear();
            txtAccount.Clear();
            txtFullName.Clear();
            cmbGender.SelectedIndex = 0;
            txtEmail.Clear();
            txtDiaChi.Clear();
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            dk = 1;
            disable(true);
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCan.Enabled = true;
        }
        private void disable(bool b)
        {
            txtFullName.Enabled = b;
            txtAccount.Enabled = b;
            txtDiaChi.Enabled = b;
            cmbGender.Enabled = b;
            dtpDob.Enabled = b;
            txtEmail.Enabled = b;
        }
        private void patientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = patientDataGridView.SelectedCells[0].Value.ToString();
            txtFullName.Text = patientDataGridView.SelectedCells[1].Value.ToString();
            txtAccount.Text = patientDataGridView.SelectedCells[2].Value.ToString();
            dtpDob.Text = patientDataGridView.SelectedCells[3].Value.ToString();
            cmbGender.Text = patientDataGridView.SelectedCells[4].Value.ToString();
            txtEmail.Text = patientDataGridView.SelectedCells[5].Value.ToString();
            txtDiaChi.Text = patientDataGridView.SelectedCells[6].Value.ToString();
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            clearfield();
            disable(false);
            btnAdd.Enabled = true;
            btnEdit.Enabled = true; 
            btnDel.Enabled = true;
            btnSave.Enabled = false;
            btnCan.Enabled = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            dk = 2;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCan.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dk = 3;
            btnDel.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCan.Enabled = true;
            disable(true);
            txtAccount.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dk == 1)
            {
                string hoten = txtFullName.Text;
                string sdt = txtAccount.Text;
                DateTime ngaysinh = dtpDob.Value;
                string matkhau = "1";
                string gioitinh = cmbGender.SelectedItem.ToString();
                string loaitaikhoan = "Bệnh nhân";
                string email = "";
                string diachi = "";
                if (checkvalid())
                {
                    try
                    {
                        ct.AddUser(hoten, sdt, ngaysinh, gioitinh, email, diachi, matkhau, loaitaikhoan, "");
                        MessageBox.Show("Đăng ký thành công");
                        clearfield();
                        loadPatient();
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDel.Enabled = true;
                        btnSave.Enabled = false;
                        btnCan.Enabled = false;
                    }
                    catch
                    {
                        msg_noti.Text = "Đã có lỗi xảy ra hoặc tài khoản đã tồn tại";
                        msg_noti.Show();
                        txtAccount.Focus();
                    }
                }
            }
            else if (dk == 2)
            {
                if (!string.IsNullOrEmpty(txtID.Text)){
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa người dùng " + txtFullName.Text + "có ID là "+txtID.Text+" hay không?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Code to execute if user clicks Yes
                        try
                        {
                            ct.deleteUser("BenhNhan", txtID.Text, "MaBenhNhan", txtAccount.Text);
                            MessageBox.Show("Xóa thành công");
                            clearfield();
                            loadPatient();

                        }
                        catch
                        {
                            msg_noti.Text = "Đã có lỗi xảy ra";
                            msg_noti.Show();
                        }
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDel.Enabled = true;
                        btnSave.Enabled = false;
                        btnCan.Enabled = false;
                    }
                    else
                    {
                        // Code to execute if user clicks No
                        clearfield();
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDel.Enabled = true;
                        btnSave.Enabled = false;
                        btnCan.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn người dùng để xóa");
                } 
            }
            else if (dk == 3)
            {
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn sửa người dùng có ID là " + txtID.Text + " hay không?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Code to execute if user clicks Yes
                        try
                        {
                            ct.editUser("BenhNhan",txtID.Text,txtFullName.Text,txtAccount.Text,dtpDob.Value,cmbGender.Text,txtEmail.Text,"",txtDiaChi.Text,"");
                            MessageBox.Show("Sửa thành công");
                            clearfield();
                            loadPatient();
                            clearfield();
                            btnAdd.Enabled = true;
                            btnEdit.Enabled = true;
                            btnDel.Enabled = true;
                            btnSave.Enabled = false;
                            btnCan.Enabled = false;
                        }
                        catch
                        {
                            msg_noti.Text = "Đã có lỗi xảy ra";
                            msg_noti.Show();
                        }
                    }
                    else
                    {
                        // Code to execute if user clicks No
                        clearfield();
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDel.Enabled = true;
                        btnSave.Enabled = false;
                        btnCan.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn người dùng để sửa đổi");
                }
            }

        }
    }
}
