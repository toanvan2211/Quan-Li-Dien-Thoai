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

namespace QuanLiDienThoai
{
    public partial class ManagerAccount : Form
    {
        public ManagerAccount()
        {
            InitializeComponent();

            //Thêm vào Item vào combobox
            cbAccountType.Items.Add("admin");
            cbAccountType.Items.Add("nhanvien");
            cbAccountType.Text = "nhanvien";

            //Load các thông tin cần thiết khi khởi tạo form
            LoadAccount();
            LoadIDEmloyees();
        }

        //Load tài khoản
        void LoadAccount()
        {
            dgvAccount.DataSource = TaiKhoanDAO.Instance.GetAccount();
        }

        //Load nhân viên
        void LoadIDEmloyees()
        {
            DataTable data = EmloyeesDAO.Instance.GetEmloyees();

            //Sử dụng LinQ để lấy danh sách mã nhân viên và add vào DataSoure của combobox Mã nhân viên
            string[] Postsource = data.AsEnumerable().Select<System.Data.DataRow, String>(x => x.Field<string>("manhanvien")).ToArray();
            var source = new AutoCompleteStringCollection();
            source.AddRange(Postsource);
            cbIDEmloyees.AutoCompleteCustomSource = source;
            cbIDEmloyees.DataSource = source;
        }

        //Sự kiện click vào các ô trong dataGridview thì hiển thị thông tin tương ứng trong các ô dữ liệu
        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAccount.CurrentRow.Selected = true;
            try
            {
                tbUserName.Text = dgvAccount.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
                tbPassword.Text = dgvAccount.Rows[e.RowIndex].Cells["matkhau"].FormattedValue.ToString();
                cbAccountType.Text = dgvAccount.Rows[e.RowIndex].Cells["loaitaikhoan"].FormattedValue.ToString();
            }
            catch
            {

            }
        }

        
        //Nút sửa
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (TaiKhoanDAO.Instance.CheckExistAccount(tbUserName.Text))
            {
                if (tbPassword.Text != "")
                {
                    int result = TaiKhoanDAO.Instance.UpdateAccount(tbUserName.Text, tbPassword.Text, cbAccountType.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công!!", "Thông báo", MessageBoxButtons.OK);
                        LoadAccount();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật tài khoản không thành công!!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK);
            }
        }

        //Nút xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TaiKhoanDAO.Instance.CheckExistAccount(tbUserName.Text))
            {
                string idEmloyees = DataProvider.Instance.ExecuteQuery("select * from taikhoan where username = '" + Login.User + "'").Rows[0]["maNhanVien"].ToString();
                if (Login.User == DataProvider.Instance.ExecuteQuery("select * from taikhoan where manhanvien = '" + idEmloyees + "'").Rows[0]["username"].ToString())
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn xóa và đăng xuất?", "Bạn đang xóa tài khoản của bạn!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        if (LoginRememberDAO.Instance.GetUser().Rows.Count > 0)
                        {
                            LoginRememberDAO.Instance.DeleteUser();
                        }
                        TaiKhoanDAO.Instance.DeleteAccount(Login.User);
                        this.Close();
                        Application.OpenForms[1].Close();
                    }
                }
                else
                {
                    TaiKhoanDAO.Instance.DeleteAccount(cbIDEmloyees.Text);
                    LoadAccount();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK);
            }
        }

        //Nút thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text != "" && tbPassword.Text != "")
            {
                if (TaiKhoanDAO.Instance.CheckExistAccount(tbUserName.Text) == false)
                {
                    if(DataProvider.Instance.ExecuteQuery("select * from taikhoan where manhanvien = '" + cbIDEmloyees.Text + "'").Rows.Count == 0)
                    {
                        int result = TaiKhoanDAO.Instance.AddAccount(tbUserName.Text, tbPassword.Text, cbAccountType.Text, cbIDEmloyees.Text);
                        if (result == 1)
                        {
                            MessageBox.Show("Thêm tài khoản thành công!!", "Thông báo", MessageBoxButtons.OK);
                            LoadAccount();
                        }
                        else
                        {
                            MessageBox.Show("Thêm tài khoản không thành công!!", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên này đã có tài khoản!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
        }

        //Nút làm mới
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadAccount();
            LoadIDEmloyees();
        }

        //Nút quản lí nhân viên
        private void btnAddEmloyees_Click(object sender, EventArgs e)
        {
            using (AddEmloyees ae = new AddEmloyees())
            {
                ae.ShowDialog();
            }
            btnRefesh.PerformClick();
        }
    }
}
