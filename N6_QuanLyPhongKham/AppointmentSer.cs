using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N6_QuanLyPhongKham
{
    public partial class AppointmentSer : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        private Account acc = new Account();
        private User us =  new User();
        public AppointmentSer()
        {
            InitializeComponent();
        }
        public void setAccVal(string acs, string psd)
        {
            acc.SDT = acs;
            acc.MatKhau = psd;
            us = ct.ShowInfo(acc,"BenhNhan");
        }
        private void AppointmentSer_Load(object sender, EventArgs e)
        {
            loadFal();
            loadApp();
            teAppTime.Time = DateTime.Today.AddHours(7);
            dtpAppDate.Value = DateTime.Now.AddDays(1);
            msg_noti.Hide();
        }
        private void loadFal() 
        {
            DataTable dt = ct.loadFal();
            cmbFal.DataSource = dt;
            cmbFal.DisplayMember = "TenKhoa";
            cmbFal.ValueMember = "MaKhoa";
        }
        private void loadDoctor(string s)
        {
            DataTable dt = ct.loadDoctor(s);
            cmbDoc.DataSource = dt;
            cmbDoc.DisplayMember = "HoTen";
            cmbDoc.ValueMember = "MaBacSi";
        }
        private void loadServices(string s)
        {
            DataTable dt = ct.loadServices(s);
            cmbSer.DataSource = dt;
            cmbSer.DisplayMember = "TenDichVu";
            cmbSer.ValueMember = "MaDichVu";
        }

        private void cmbFal_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoc.Text = "";
            cmbSer.Text = "";
            if (cmbFal.SelectedIndex != -1)
            {
                var selectedValue = cmbFal.SelectedValue.ToString();
                // Do something with the selected value
                loadDoctor(selectedValue);
                loadServices(selectedValue);
            }
        }
        private void clearfield()
        {
          
            txtMota.Clear();
            cmbFal.SelectedIndex = 0;
            cmbDoc.SelectedIndex = 0;
            cmbSer.SelectedIndex = 0;
            teAppTime.Time = DateTime.Today.AddHours(7);
            dtpAppDate.Value= DateTime.Now.AddDays(1);
        }

        /*Kiểm tra xem đã chọn bác sĩ và dịch vụ chưa*/
        private bool checkvalid()
        {
            if (cmbDoc.SelectedIndex == -1) {
                msg_noti.Text = "Bạn chưa chọn bác sĩ";
                msg_noti.Show();
                return false;
            }
            else if(cmbSer.SelectedIndex == -1)
            {
                msg_noti.Text = "Bạn chưa chọn dịch vụ";
                msg_noti.Show();
                return false;
            }
            return true;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (checkvalid())
            {
                try
                {
                    msg_noti.Hide();
                    ct.addAppDate(us.ID, cmbDoc.SelectedValue.ToString(), cmbSer.SelectedValue.ToString(), dtpAppDate.Value, DateTime.ParseExact(teAppTime.Text, "h:mm:ss tt", CultureInfo.InvariantCulture).TimeOfDay, 0, txtMota.Text);
                    loadApp();
                    clearfield();
                }
                catch
                {
                    /*MessageBox.Show("Đã có lỗi xảy ra");*/
                }
            }
        }

        private void teAppTime_Validating(object sender, CancelEventArgs e)
        {
            var value = teAppTime.Time.TimeOfDay;
            if (value < new TimeSpan(7, 0, 0) || value > new TimeSpan(17, 0, 0))
            {
                e.Cancel = true;
                MessageBox.Show("Giá trị không hợp lệ! Thời gian đặt lịch hẹn phải nằm trong khoảng từ 7:00 đến 17:00");
            }
        }
        private void loadApp()
        {
            DataTable dt = ct.loadAppRegister(us.ID);
            appDataGridView.DataSource= dt;
            if(dt.Rows.Count == 0)
            {
                btnCan.Enabled= false;
            }
            else
            {
                btnCan.Enabled= true;
            }
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            int rowIndex = appDataGridView.CurrentCell.RowIndex;

            // Lấy ra thông tin cột "LichHen" của hàng đó
            string id = appDataGridView.Rows[rowIndex].Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show("Bạn có muốn hủy lịch hẹn có mã số " + id + " hay không?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ct.delAppDate(id);
                MessageBox.Show("Hủy lịch hẹn thành công");
                loadApp();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMota.Text = "";
            teAppTime.Time = DateTime.Today.AddHours(7);
            dtpAppDate.Value = DateTime.Now.AddDays(1);
        }

        private void dtpAppDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpAppDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Ngày đặt lịch hẹn phải lớn hơn ngày hiện tại 1 ngày");
                dtpAppDate.Value = DateTime.Now.AddDays(1);
            }
        }
    }
}
