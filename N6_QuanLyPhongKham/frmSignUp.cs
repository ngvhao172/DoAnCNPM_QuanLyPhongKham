using System.Text.RegularExpressions;

namespace N6_QuanLyPhongKham
{
    public partial class frmSignUp : Form
    {

        private Controller ct = new Controller();
        public frmSignUp()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            msg_noti.Hide();
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.FlatAppearance.BorderSize = 0;
        }
        /* private bool IsValidEmail(string email)
         {
             try
             {
                 Regex rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
                 return rx.IsMatch(email);
             }
             catch (FormatException)
             {
                 return false;
             }
         }*/
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
        private bool confirmPassword(string a, string b)
        {
            if (a == b)
            {
                return true;
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
            /*else if (string.IsNullOrEmpty(txtEmail.Text))
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
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                msg_noti.Text = "Mật khẩu không được để trống";
                msg_noti.Show();
                txtFullName.Focus();
                return false;
            }
            else
            {
                /*if (IsValidEmail(txtEmail.Text) == false)
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
                else if (confirmPassword(txtPassword.ToString(), txtConfirmPsw.ToString()) == false)
                {
                    msg_noti.Text = "Mật khẩu không trùng khớp";
                    msg_noti.Show();
                    txtPassword.Focus();
                    return false;

                }
            }
            return true;
        }
        private void clearfield()
        {
            txtAccount.Clear();
            txtPassword.Clear();
            txtConfirmPsw.Clear();
            txtFullName.Clear();
            cmbGender.SelectedIndex = 0;

        }

        public void btnSignUp_Click(object sender, EventArgs e)
        {
            string hoten = txtFullName.Text;
            string sdt = txtAccount.Text;
            DateTime ngaysinh = dtpDob.Value;
            string matkhau = txtPassword.Text;
            string gioitinh = "Nam";
            string loaitaikhoan = "Bệnh nhân";
            string email = "";
            string diachi = "";
            if (checkvalid())
            {
                try
                {
                    ct.AddUser(hoten, sdt, ngaysinh, gioitinh, email, diachi, matkhau, loaitaikhoan,"");
                    MessageBox.Show("Đăng ký thành công");
                    clearfield();
                }
                catch
                {
                    msg_noti.Text = "Đã có lỗi xảy ra hoặc tài khoản đã tồn tại";
                    msg_noti.Show();
                    txtAccount.Focus();
                }
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin form2 = new frmLogin();
            form2.ShowDialog();
            this.Close();
        }

    }
}