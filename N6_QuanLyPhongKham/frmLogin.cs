namespace N6_QuanLyPhongKham
{
    public partial class frmLogin : Form
    {
        private Controller ct = new Controller();
        public frmLogin()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
            pBtick.Hide();
            msg_noti.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSignUp form1 = new frmSignUp();
            form1.ShowDialog();
            this.Close();
        }
        private bool checkvalid()
        {
            if (string.IsNullOrEmpty(txtAccount.Text))
            {
                msg_noti.Text = "Bạn chưa nhập tài khoản";
                msg_noti.Show();
                txtAccount.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                msg_noti.Text = "Bạn chưa nhập mật khẩu";
                msg_noti.Show();
                txtPassword.Focus();
                return false;
            }
            return true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (checkvalid()) {
                if (txtAccount.Text == "admin" && txtPassword.Text == "admin")
                {
                    MessageBox.Show("Đăng nhập thành công");
                    msg_noti.Hide();
                    this.Hide();
                    Mainform mf = new Mainform();
                    mf.setAccVal(txtAccount.Text, txtPassword.Text);
                    mf.ShowDialog();
                    this.Close();
                }
                else
                {
                    msg_noti.Text = "";
                    msg_noti.Hide();
                    try
                    {
                        if (ct.Login(txtAccount.Text, txtPassword.Text) == "success")
                        {
                            MessageBox.Show("Đăng nhập thành công");
                            msg_noti.Hide();
                            this.Hide();
                            Mainform mf = new Mainform();
                            mf.setAccVal(txtAccount.Text, txtPassword.Text);
                            mf.ShowDialog();
                            this.Close();

                        }
                        else if (ct.Login(txtAccount.Text, txtPassword.Text) == "notexist")
                        {
                            msg_noti.Text = "Tài khoản không tồn tại";
                            msg_noti.Show();
                        }
                        else
                        {
                            msg_noti.Text = "Tài khoản hoặc mật khẩu không đúng";
                            msg_noti.Show();
                        }
                    }
                    catch
                    {
                        msg_noti.Text = "Đã có lỗi xảy ra";
                        msg_noti.Show();
                    }
                }      
            }
        }
        
    }
    
}
