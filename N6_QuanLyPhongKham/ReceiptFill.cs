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
    public partial class ReceiptFill : DevExpress.XtraEditors.XtraUserControl
    {
        private Account acc = new Account();
        private Controller ct = new Controller();
        public void setAccVal(string acs, string psd)
        {
            acc.SDT = acs;
            acc.MatKhau = psd;
        }
        public ReceiptFill()
        {
            InitializeComponent();
        }
        private bool checkvalid()
        {
            if (string.IsNullOrEmpty(txtPreID.Text))
            {
                msg_noti.Text = "Bạn chưa nhập mã đơn thuốc";
                msg_noti.Show();
                txtPreID.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                msg_noti.Text = "Bạn chưa nhập tên thuốc";
                msg_noti.Show();
                txtName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                msg_noti.Text = "Bạn chưa nhập số lượng";
                msg_noti.Show();
                txtPrice.Focus();
                return false;
            }  
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(checkvalid())
            {
                string giatien = txtPrice.Text;
                string machtietdonthuoc = prescriptionDataGridView.SelectedCells[0].Value.ToString();
                try
                {
                    ct.editPrescriptionDetail(machtietdonthuoc, giatien);
                    loadPrescriptionDetail();
                    msg_noti.Hide();
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
            prescriptionDataGridView.DataSource = dt;
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            loadPrescriptionDetail();
            msg_noti.Hide();
        }

        private void txtPreID_TextChanged(object sender, EventArgs e)
        {
            loadPrescriptionDetail();
        }

        private void prescriptionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = prescriptionDataGridView.SelectedCells[1].Value.ToString();
            txtPrice.Text = prescriptionDataGridView.SelectedCells[5].Value.ToString();
        }

        private void btnGetReceipt_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string tongtien = ct.getTotal(txtPreID.Text);
            
            try
            {
                ct.addReceipt(txtPreID.Text, dt, tongtien);
                ReceiptLayout rl = new ReceiptLayout(txtPreID.Text);
                rl.setAccVal(acc.SDT, acc.MatKhau);
                rl.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }
            
        }
    }
}
