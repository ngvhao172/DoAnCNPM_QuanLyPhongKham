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
    public partial class ServicesData : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        private int dk;
        public ServicesData()
        {
            InitializeComponent();
            msg_noti.Hide();
        }

        private void ServicesData_Load(object sender, EventArgs e)
        {
            loadFal();
            loadSer();
            txtID.Enabled = false;
            disable(false);
        }
        private void clearfield()
        {
            txtID.Clear();
            txtServiceName.Clear();
            cmbFal.SelectedIndex = 0;
            txtPrice.Clear();
        }
        private bool checkvalid()
        {
            if (string.IsNullOrEmpty(txtServiceName.Text))
            {
                msg_noti.Text = "Tên dịch vụ không được để trống";
                msg_noti.Show();
                txtServiceName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                msg_noti.Text = "Giá dịch vụ không được để trống";
                msg_noti.Show();
                txtPrice.Focus();
                return false;

            }
            msg_noti.Hide();
            return true;
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            dk = 1;
            disable(true);
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCan.Enabled = true;
            msg_noti.Hide();
        }
        private void disable(bool b)
        {
            txtServiceName.Enabled = b;
            txtPrice.Enabled = b;
            cmbFal.Enabled = b;
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
            msg_noti.Hide();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            dk = 2;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCan.Enabled = true;
            msg_noti.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dk = 3;
            btnDel.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCan.Enabled = true;
            disable(true);
            msg_noti.Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            msg_noti.Hide();
            if (dk == 1)
            {
                string tendichvu = txtServiceName.Text;
                string giadichvu = txtPrice.Text;
                string makhoa = cmbFal.SelectedValue.ToString();
                if (checkvalid())
                {
                    try
                    {
                        ct.addService(tendichvu, giadichvu,makhoa);
                        MessageBox.Show("Đăng ký thành công");
                        clearfield();
                        loadSer();
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
            }
            else if (dk == 2)
            {
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa dịch vụ " + txtServiceName.Text + "có ID là " + txtID.Text + " hay không?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Code to execute if user clicks Yes
                        try
                        {
                            ct.delService(txtID.Text);
                            MessageBox.Show("Xóa thành công");
                            clearfield();
                            loadSer();

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
                    MessageBox.Show("Bạn chưa chọn dịch vụ để xóa");
                }
            }
            else if (dk == 3)
            {
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn sửa dịch vụ có ID là " + txtID.Text + " hay không?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Code to execute if user clicks Yes
                        try
                        {
                            ct.editService(txtID.Text, txtServiceName.Text, txtPrice.Text, cmbFal.SelectedValue.ToString());
                            MessageBox.Show("Sửa thành công");
                            clearfield();
                            loadSer();
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
                    MessageBox.Show("Bạn chưa chọn dịch vụ để sửa đổi");
                }
            }
        }
        private void patientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = serviceDataGridView.SelectedCells[0].Value.ToString();
            txtServiceName.Text = serviceDataGridView.SelectedCells[1].Value.ToString();
            txtPrice.Text = serviceDataGridView.SelectedCells[2].Value.ToString();
            cmbFal.Text = serviceDataGridView.SelectedCells[3].Value.ToString();
        }
        private void loadFal()
        {
            DataTable dt = ct.loadFal();
            cmbFal.DataSource = dt;
            cmbFal.DisplayMember = "TenKhoa";
            cmbFal.ValueMember = "MaKhoa";

        }
        private void loadSer()
        {
            DataTable tb = ct.loadServices();
            serviceDataGridView.DataSource = tb;
        }
    }
}
