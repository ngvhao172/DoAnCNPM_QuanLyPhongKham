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
    public partial class EmployeeData : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        private int dk;
        public EmployeeData()
        {
            InitializeComponent();
        }

        private void DoctorData_Load(object sender, EventArgs e)
        {
            loadDoctor();
            loadFal();

            cmbFal.SelectedItem= null;
            cmbGender.SelectedItem = null;
            cmbRole.SelectedItem = null;
            txtID.Enabled= false;
            btnSave.Enabled= false;
            btnCan.Enabled= false;
           
            disable(false);
        }
        private void loadDoctor()
        {
            DataTable dt = ct.loadDoctor();
            employeeDataGridView.DataSource = dt;
            msg_noti.Hide();
        }
        private void loadEm()
        {
            DataTable dt = ct.loadEmployee();
            employeeDataGridView.DataSource = dt;
            msg_noti.Hide();
        }
        private void loadAccountant()
        {
            DataTable dt = ct.loadAccountant();
            employeeDataGridView.DataSource = dt;
            msg_noti.Hide();
        }
        /*Xóa hết các trường dữ liệu*/
        private void clearfield()
        {
            txtID.Clear();
            txtPhoneNumber.Clear();
            txtFullName.Clear();
            cmbGender.SelectedIndex = 0;
            txtSalary.Clear();
            txtDiaChi.Clear();
            cmbFal.SelectedIndex= 0;
        }
        /*Ràng buộc trường dữ liệu 10<=SDT.length<=11 */
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
        /*Kiểm tra các trường dữ liệu đã được điền vào hay chưa*/
        private bool checkvalid()
        {
            if (string.IsNullOrEmpty(cmbRole.Text))
            {
                msg_noti.Text = "Hãy chọn tác nhân cần được thêm";
                msg_noti.Show();
                cmbRole.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtFullName.Text))
            {
                msg_noti.Text = "Họ tên không được để trống";
                msg_noti.Show();
                txtFullName.Focus();
                if(cmbRole.Text != "Bác sĩ")
                {
                    cmbFal.Text = "1";
                }
                return false;
            }
            else if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                msg_noti.Text = "Số điện thoại không được để trống";
                msg_noti.Show();
                txtPhoneNumber.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbGender.Text))
            {
                msg_noti.Text = "Giới tính không được để trống";
                msg_noti.Show();
                cmbGender.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSalary.Text))
            {
                msg_noti.Text = "Lương không được để trống";
                msg_noti.Show();
                txtSalary.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbFal.Text))
            {
                msg_noti.Text = "Mã khoa không được để trống";
                msg_noti.Show();
                cmbFal.Focus();
                return false;
            }
            else
            {
                if (isValidAccount(txtPhoneNumber.Text) == false)
                {
                    msg_noti.Text = "Số điện thoại phải bắt đầu bằng số 0 và chứa 10 hoặc 11 số";
                    msg_noti.Show();
                    txtPhoneNumber.Focus();
                    return false;
                }
            }
            msg_noti.Hide();
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
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
            txtPhoneNumber.Enabled = b;
            txtDiaChi.Enabled = b;
            cmbGender.Enabled = b;
            dtpDob.Enabled = b;
            cmbFal.Enabled = b;
            txtSalary.Enabled = b;

        }
        private void loadFal()
        {
            DataTable dt = ct.loadFal();
            cmbFal.DataSource = dt;
            cmbFal.DisplayMember = "TenKhoa";
            cmbFal.ValueMember = "MaKhoa";

        }

        private void doctorDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = employeeDataGridView.SelectedCells[0].Value.ToString();
            txtFullName.Text = employeeDataGridView.SelectedCells[1].Value.ToString();
            txtPhoneNumber.Text = employeeDataGridView.SelectedCells[2].Value.ToString();
            dtpDob.Text = employeeDataGridView.SelectedCells[3].Value.ToString();
            cmbGender.Text = employeeDataGridView.SelectedCells[4].Value.ToString();
            txtSalary.Text = employeeDataGridView.SelectedCells[5].Value.ToString();
            if(cmbRole.Text == "Bác sĩ")
            {
                cmbFal.Text = employeeDataGridView.SelectedCells[6].Value.ToString();
                txtDiaChi.Text = employeeDataGridView.SelectedCells[7].Value.ToString();
            }
            else
            {
                txtDiaChi.Text = employeeDataGridView.SelectedCells[6].Value.ToString();
            }
           
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
            txtPhoneNumber.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (dk == 1)
            {
                string hoten = txtFullName.Text;
                string sdt = txtPhoneNumber.Text;
                DateTime ngaysinh = dtpDob.Value;
                string matkhau = "";
                if (matkhau == "")
                    matkhau = "1";
                string luong = txtSalary.Text;
                string makhoa = "1";
                if (checkvalid())
                {
                    string gioitinh = cmbGender.SelectedItem.ToString();
                    string loaitaikhoan = cmbRole.SelectedItem.ToString();
                    if (cmbRole.Text == "Bác sĩ")
                    {
                        makhoa = cmbFal.SelectedValue.ToString();
                    }
                    try
                    {
                        ct.AddUser(hoten, sdt, ngaysinh, gioitinh, makhoa, "", matkhau, loaitaikhoan, luong);
                        MessageBox.Show("Đăng ký thành công");
                        clearfield();
                        disable(false);
                        loadDoctor();
                    }
                    catch
                    {
                        msg_noti.Text = "Đã có lỗi xảy ra hoặc tài khoản đã tồn tại";
                        msg_noti.Show();
                        txtPhoneNumber.Focus();

                    }
                }
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
                btnSave.Enabled = false;
                btnCan.Enabled = false;
            }
            else if (dk == 2)
            {
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    string role = txtID.Text.Substring(0, 2);
                    string bang = "";
                    string id = "";
                    if (role == "BS")
                    {
                        bang = "BacSi";
                        id = "MaBacSi";
                    }
                    if (role == "NV")
                    {
                        bang = "NhanVien";
                        id = "MaNhanVien";
                    }
                    if (role == "KT")
                    {
                        bang = "KeToan";
                        id = "MaKeToan";
                    }
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa người dùng " + txtFullName.Text.Trim() + " có ID là " + txtID.Text.Trim() + " hay không?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Code to execute if user clicks Yes
                        try
                        {
                            ct.deleteUser(bang, txtID.Text, id, txtPhoneNumber.Text);
                            MessageBox.Show("Xóa thành công");
                            clearfield();
                            loadDoctor();
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
                    MessageBox.Show("Bạn chưa chọn người dùng để xóa đổi");
                }
            }
            else if (dk == 3)
            {
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    string role = txtID.Text.Substring(0, 2);
                    string bang = "";
                    if (role == "BS")
                    {
                        bang = "BacSi";

                    }
                    if (role == "NV")
                    {
                        bang = "NhanVien";
                    }
                    if (role == "KT")
                    {
                        bang = "KeToan";
                    }
                    DialogResult result = MessageBox.Show("Bạn có muốn sửa người dùng có ID là " + txtID.Text.Trim() + " hay không?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Code to execute if user clicks Yes
                        try
                        {
                            ct.editUser(bang, txtID.Text, txtFullName.Text, txtPhoneNumber.Text, dtpDob.Value, cmbGender.Text, "", cmbFal.SelectedValue.ToString(), txtDiaChi.Text, txtSalary.Text);
                            MessageBox.Show("Sửa thành công");
                            clearfield();
                            loadDoctor();
                            disable(false);
                        }
                        catch
                        {
                            msg_noti.Text = "Đã có lỗi xảy ra";
                            msg_noti.Show();
                            clearfield();
                            loadDoctor();
                            disable(false);
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
                    MessageBox.Show("Bạn chưa chọn người dùng để sửa đổi");
                }
            }
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

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedIndex != -1)
            {
                var selectedValue = cmbRole.SelectedItem.ToString();
                // Do something with the selected value
                if (selectedValue == "Bác sĩ")
                {
                    loadDoctor();
                    cmbFal.Show();
                    label7.Show();
                }
                if (selectedValue == "Nhân viên")
                {
                    loadEm();
                    cmbFal.Text = "1";
                    cmbFal.Hide();
                    label7.Hide();
                }
                if (selectedValue == "Kế toán")
                {
                    loadAccountant();
                    cmbFal.Text = "1";
                    cmbFal.Hide();
                    label7.Hide();
                }
            } 
        }
    }
}
