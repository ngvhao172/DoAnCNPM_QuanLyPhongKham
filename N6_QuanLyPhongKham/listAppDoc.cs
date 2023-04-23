using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;
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
    public partial class listAppDoc : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        private Account acc = new Account();
        private User us = new User();
        private string madonthuoc;
        public listAppDoc()
        {
            InitializeComponent();
        }
        private void listAppDoc_Load(object sender, EventArgs e)
        {
            loadlistAppDoc();
        }
        public void setAccVal(string acs, string psd)
        {
            acc.SDT = acs;
            acc.MatKhau = psd;
            us = ct.ShowInfo(acc,"BacSi");
        }
        public string getMaHoaDon()
        {
            return madonthuoc;
        }
        private void loadlistAppDoc()
        {
            DataTable dt = ct.loadListAppDoc(us.ID);
            listAppDocDataGridView.DataSource = dt;
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            string id = listAppDocDataGridView.SelectedCells[0].Value.ToString(); /*Mã lịch hẹn*/
            string mabenhnhan = listAppDocDataGridView.SelectedCells[1].Value.ToString();
            string mabacsi = listAppDocDataGridView.SelectedCells[2].Value.ToString();
            string madichvu = listAppDocDataGridView.SelectedCells[3].Value.ToString();
            DateTime ngayhen = Convert.ToDateTime(listAppDocDataGridView.SelectedCells[4].Value.ToString());
           /* string giohen = listAppDocDataGridView.SelectedCells[5].Value.ToString();*/
            /*string tongtien = ct.getMoneyService(madichvu);*/
            string tongtien = "";
            string check = "";
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    ct.updateCompleteState(id);
                    loadlistAppDoc();
                    check = "completed";
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
            if(check == "completed") /*Tạo đơn thuốc khi đã trạng thái chuyển sang hoàn thành(2)*/
            {
                madonthuoc = ct.addPres(mabenhnhan, mabacsi, id, ngayhen, tongtien);
                Mainform mainForm = (Mainform)this.ParentForm; // lấy ra đối tượng MainForm chứa listAppDoc
                mainForm.setMadonthuoc(madonthuoc); // truyền giá trị madonthuoc sang MainForm
            }
        }
    }
}
