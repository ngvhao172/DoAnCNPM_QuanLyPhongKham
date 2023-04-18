using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab5_52100792
{
    public partial class Form1 : Form
    {
        DataModel dm;
        public Form1()
        {
            InitializeComponent();
            LoadDataModel();
        }

        private void LoadDataModel()
        {
            dm = new DataModel();

        }
        public void ResetForm()
        {
            viewerDataGridView.Rows.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadViewerData();
        }
        private void LoadViewerData()
        {
            List<Dictionary<string, string>> rows = dm.FetchAllRow();
            foreach (Dictionary<string, string> row in rows)
            {
                int index = viewerDataGridView.Rows.Add();
                viewerDataGridView.Rows[index].Cells[0].Value = row["ID"];
                viewerDataGridView.Rows[index].Cells[1].Value = row["FullName"];
                viewerDataGridView.Rows[index].Cells[2].Value = row["Dob"];

            } 
        }

        private void InitializeForm()
        {
            viewerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void ClearFilled()
        {
            txtFullName.Clear();
            txtID.Clear();
            txtIDSearch.Clear();
        }
        private void disablebtn(bool b)
        {
            btnAdd.Enabled= b;
            btnDel.Enabled= b;
            btnEdit.Enabled= b;
            btnSearch.Enabled= b;
        }
        bool check = false;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (check == false)
            {
                disablebtn(false);
                btnAdd.Enabled = true;
                check = true;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin");
                }
                else
                {

                    if (!dm.AddNewRow(txtID.Text.Trim(), txtFullName.Text.Trim(), dtpDob.Value.ToString()))
                    {
                        MessageBox.Show("Đã có lỗi xảy ra");
                    }
                    else
                    {
                        MessageBox.Show("Thêm độc giả mới thành công");
                        disablebtn(true);
                        check = false;
                    }
                }
            }
            ClearFilled();
            ResetForm();
            LoadViewerData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!dm.RemoveRow(viewerDataGridView.Rows[viewerDataGridView.SelectedRows[0].Index].Cells[0].Value.ToString()))
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }
            else
            {
                MessageBox.Show("Xóa độc giả thành công");
            }
            ResetForm();
            LoadViewerData();
  
        }
        private void viewerDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = viewerDataGridView.SelectedCells[0].Value.ToString().Trim();
            txtFullName.Text = viewerDataGridView.SelectedCells[1].Value.ToString().Trim();
            dtpDob.Text = viewerDataGridView.SelectedCells[2].Value.ToString().Trim();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (check == false)
            {
                disablebtn(false);
                btnEdit.Enabled = true;
                check = true;
            }
            else
            {
                if (!dm.EditRow(txtID.Text.Trim(), txtFullName.Text.Trim(), dtpDob.Value.ToString(), viewerDataGridView.SelectedCells[0].Value.ToString().Trim()))
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
                else
                {
                    MessageBox.Show("Sửa độc giả thành công");
                    check = false;
                    disablebtn(true);
                }
            }
           
            ClearFilled();
            ResetForm();
            LoadViewerData();

        }
        private bool Search(string id)
        {
            List<Dictionary<string, string>> rows = dm.FetchAllRow();
            foreach (Dictionary<string, string> row in rows)
            {
                if (row["ID"].ToString().Trim() == id)
                {
                    return true;

                }
            }
            return false;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            viewerDataGridView.Rows.Clear();
            List<Dictionary<string, string>> rows = dm.FetchAllRow();
            if(txtIDSearch.Text == " ")
            {
                MessageBox.Show("Bạn chưa điền mã độc giả");
                LoadViewerData();
            }
            else
            {
                if (Search(txtIDSearch.Text) == true)
                {
                    viewerDataGridView.Rows.Clear();
                    foreach (Dictionary<string, string> row in rows)
                    {
                        if (row["ID"].ToString().Trim() == txtIDSearch.Text)
                        {
                            int index = viewerDataGridView.Rows.Add();
                            viewerDataGridView.Rows[index].Cells[0].Value = row["ID"];
                            viewerDataGridView.Rows[index].Cells[1].Value = row["FullName"];
                            viewerDataGridView.Rows[index].Cells[2].Value = row["Dob"];
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy độc giả");
                    LoadViewerData();
                }
            }
            
        }
    }
}