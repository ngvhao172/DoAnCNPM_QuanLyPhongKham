namespace N6_QuanLyPhongKham
{
    public partial class ChangePsd : DevExpress.XtraEditors.XtraUserControl
    {
        private Account acc = new Account();
        private Controller ct = new Controller();
        public void setAccVal(string acs, string psd)
        {
            acc.SDT = acs;
            acc.MatKhau = psd;
        }
        public ChangePsd()
        {
            InitializeComponent();
            msg_noti.Hide();
        }
        public bool checkvalid()
        {
            InforOfUser iu = new InforOfUser();
            if (string.IsNullOrEmpty(txtoldPsd.Text))
            {
                msg_noti.Text = "Bạn chưa nhập mật khẩu cũ";
                msg_noti.Show();
                txtoldPsd.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtnewPsd.Text))
            {
                msg_noti.Text = "Bạn chưa nhập mật khẩu mới";
                msg_noti.Show();
                txtnewPsd.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtconfirmnewPsd.Text))
            {
                msg_noti.Text = "Bạn chưa nhập lại mật khẩu mới";
                msg_noti.Show();
                txtconfirmnewPsd.Focus();
                return false;
            }
            return true;
        }
        private void btnConfirmPsd_Click(object sender, EventArgs e)
        {
            msg_noti.Hide();
            if (checkvalid())
            {
                if (txtoldPsd.Text == acc.MatKhau)
                {
                    if (txtconfirmnewPsd.Text == txtnewPsd.Text)
                    {
                        try
                        {
                            ct.ChangePsd(txtnewPsd.Text, acc);
                            msg_noti.Text = "Đổi mật khẩu thành công";
                            msg_noti.ForeColor = Color.Green;
                            msg_noti.Show();
                            txtoldPsd.Text = "";
                            txtnewPsd.Text = "";
                            txtconfirmnewPsd.Text = "";
                        }
                        catch
                        {
                            msg_noti.Text = "Đã có lỗi xảy ra";
                            msg_noti.Show();
                        }
                    }
                    else
                    {
                        msg_noti.Text = "Mật khẩu không trùng khớp";
                        txtnewPsd.Focus();
                        msg_noti.Show();
                    }
                }
                else
                {
                    msg_noti.Text = "Mật khẩu cũ không chính xác";
                    msg_noti.Show();
                    txtoldPsd.Focus();
                }
            }
        }
    }
}
