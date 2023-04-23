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
    public partial class SpecialityData : DevExpress.XtraEditors.XtraUserControl
    {
        private Controller ct = new Controller();
        private int dk;
        public SpecialityData()
        {
            InitializeComponent();
            msg_noti.Hide();
            txtID.Enabled= false;
        }
        public void loadSpecial()
        {
            DataTable tb = ct.loadFal();
            specialityDataGridView.DataSource = tb;
        }

        private void SpecialityData_Load(object sender, EventArgs e)
        {
            loadSpecial();
        }
        private bool checkvalid()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                msg_noti.Text = "Mã khoa không được để trống";
                msg_noti.Show();
                txtID.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtFullName.Text))
            {
                msg_noti.Text = "Tên khoa không được để trống";
                msg_noti.Show();
                txtFullName.Focus();
                return false;

            }
            return true;
        }
        private void clearfield()
        {
            txtID.Clear();
            txtFullName.Clear();
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            dk = 1;
            disable(true);
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCan.Enabled = true;
            txtID.Enabled = true;
        }
        private void disable(bool b)
        {
            txtFullName.Enabled = b;
        }
        private void serviceDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = specialityDataGridView.SelectedCells[0].Value.ToString();
            txtFullName.Text = specialityDataGridView.SelectedCells[1].Value.ToString();
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
            txtID.Enabled=false;
            btnDel.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCan.Enabled = true;
            disable(true);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtID.Enabled=false;
            if (dk == 1)
            {
                string makhoa = txtID.Text;
                string tenkhoa = txtFullName.Text;
                if (checkvalid())
                {
                    try
                    {
                        ct.addSpeciality(makhoa, tenkhoa);
                        MessageBox.Show("Đăng ký thành công");
                        clearfield();
                        loadSpecial();
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDel.Enabled = true;
                        btnSave.Enabled = false;
                        btnCan.Enabled = false;
                    }
                    catch
                    {
                        msg_noti.Text = "Đã có lỗi xảy ra hoặc mã khoa đã tồn tại";
                        msg_noti.Show();
                        txtID.Focus();
                    }
                }
            }
            else if (dk == 2)
            {
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa khoa " + txtFullName.Text + "có ID là " + txtID.Text + " hay không?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Code to execute if user clicks Yes
                        try
                        {
                            ct.deleteSpeciality(txtID.Text);
                            MessageBox.Show("Xóa thành công");
                            clearfield();
                            loadSpecial();

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
        }
    }
}
