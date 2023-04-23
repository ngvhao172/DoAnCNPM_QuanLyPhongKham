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
    public partial class ListAppointment : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        public ListAppointment()
        {
            InitializeComponent();
        }
        private void ListAppointment_Load(object sender, EventArgs e)
        {
            loadListApp();
            btnComplete.Enabled = false;
        }
        public void loadListApp()
        {
            DataTable dt = ct.loadListApp();
            listAppDataGridView.DataSource = dt;
            
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string id = listAppDataGridView.SelectedCells[0].Value.ToString();
            if (!string.IsNullOrEmpty(id) ) {
                try
                {
                    ct.updateConfirmState(id);
                    loadListApp();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn bệnh nhân để chuyển trạng thái");
            }
            
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            string id = listAppDataGridView.SelectedCells[0].Value.ToString();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    ct.delAppDate(id);
                    loadListApp();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn bệnh nhân để hủy lịch hẹn");
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            string id = listAppDataGridView.SelectedCells[0].Value.ToString();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    ct.updateCompleteState(id);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn bệnh nhân để hoàn thành lịch hẹn");
            }
        }
    }
}
