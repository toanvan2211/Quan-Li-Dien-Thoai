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
    public partial class UpdateInfo : Form
    {
        //Tương tự form quản lí tài khoản

        static string id = TaiKhoanDAO.Instance.GetID(Login.User); //Lấy id nhân viên dựa vào userName lúc đăng nhập
        Emloyees em = EmloyeesDAO.Instance.GetEmloyeesWithID(id); //Tạo ra một biến kiểu nhân viên, để lưu thông tin từ csdl vào

        public UpdateInfo()
        {
            InitializeComponent();
            LoadCbSex();
            LoadInfo();
        }

        
        void LoadCbSex()
        {
            cbSex.Items.Add("Không xác định");
            cbSex.Items.Add("Nam");
            cbSex.Items.Add("Nữ");
            cbSex.SelectedItem = "Nam";
        }

        void LoadInfo()
        {
            
            tbName.Text = em.Ten;
            cbSex.SelectedItem = em.GioiTinh;
            tbAddress.Text = em.DiaChi;
            tbPhoneNumber.Text = em.SoDT;
        }
        
        //Nút trở về
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Nút cập nhật
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "")
            {
                em.Ten = tbName.Text;
                em.GioiTinh = cbSex.SelectedIndex.ToString();
                em.DiaChi = tbAddress.Text;
                em.SoDT = tbPhoneNumber.Text;
                int result = EmloyeesDAO.Instance.UpdateEmloyees(id, em.Ten, em.GioiTinh, em.DiaChi, em.SoDT);
                if (result == 1)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin không thành công!!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
