using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiDienThoai.DAO;
using QuanLiDienThoai.DTO;

namespace QuanLiDienThoai
{
    public partial class AddEmloyees : Form
    {

        //Tương tự như form quản lí tài khoản
        public AddEmloyees()
        {
            InitializeComponent();
            cbSex.Items.Add("Không xác định");
            cbSex.Items.Add("Nam");
            cbSex.Items.Add("Nữ");
            cbSex.SelectedIndex = 1;

            LoadEmloyees();
        }

        void LoadEmloyees()
        {
            dgvEmloyees.DataSource = EmloyeesDAO.Instance.GetEmloyees();

            tbIDEmloyees.Text = "";
            tbName.Text = "";
            cbSex.Text = "Nam";
            tbAddress.Text = "";
            tbPhoneNumber.Text = "";
        }

        bool CheckTextBoxNull()
        {
            bool check = true;
            if (tbIDEmloyees.Text != "" && tbName.Text != "")
            {
                check = false;
            }
            return check;
        }

        private void dgvEmloyees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEmloyees.CurrentRow.Selected = true;
            try
            {
                tbIDEmloyees.Text = dgvEmloyees.Rows[e.RowIndex].Cells["maNhanVien"].FormattedValue.ToString();
                tbName.Text = dgvEmloyees.Rows[e.RowIndex].Cells["ten"].FormattedValue.ToString();
                int index = 1;
                int.TryParse(dgvEmloyees.Rows[e.RowIndex].Cells["gioitinh"].FormattedValue.ToString(), out index);
                cbSex.SelectedIndex = index;
                tbAddress.Text = dgvEmloyees.Rows[e.RowIndex].Cells["diaChi"].FormattedValue.ToString();
                tbPhoneNumber.Text = dgvEmloyees.Rows[e.RowIndex].Cells["sdt"].FormattedValue.ToString();
            }
            catch
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (EmloyeesDAO.Instance.CheckExistEmloyees(tbIDEmloyees.Text) == false)
            {
                if (CheckTextBoxNull() == false)
                {
                    EmloyeesDAO.Instance.AddEmloyees(tbIDEmloyees.Text, tbName.Text, cbSex.SelectedIndex.ToString(), tbAddress.Text, tbPhoneNumber.Text);
                    LoadEmloyees();
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Nhân viên đã tồn tại.", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (EmloyeesDAO.Instance.CheckExistEmloyees(tbIDEmloyees.Text))
            {
                if (CheckTextBoxNull() == false)
                {
                    EmloyeesDAO.Instance.UpdateEmloyees(tbIDEmloyees.Text, tbName.Text, cbSex.SelectedIndex.ToString(), tbAddress.Text, tbPhoneNumber.Text);
                    MessageBox.Show("Đã cập nhật thông tin!", "Thông báo", MessageBoxButtons.OK);
                    LoadEmloyees();
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Nhân viên không tồn tại.", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadEmloyees();
        }
    }
}
