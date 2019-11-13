using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiDienThoai.DTO;
using QuanLiDienThoai.DAO;

namespace QuanLiDienThoai.UC
{
    public partial class UC_Info : UserControl
    {
        public UC_Info()
        {
            InitializeComponent();
            LoadInfo();
        }

        #region method

        //Load thông tin
        void LoadInfo()
        {

            string id = TaiKhoanDAO.Instance.GetID(Login.User);
            Emloyees em = EmloyeesDAO.Instance.GetEmloyeesWithID(id);

            lbUserName.Text = "Tên tài khoản:   " + Login.User;
            lbID.Text = "Mã:   " + em.MaNhanVien;
            lbName.Text = "Tên:   " + em.Ten;
            lbSex.Text = "Giới tính:   " + em.GioiTinh;
            lbAddress.Text = "Địa chỉ:   " + em.DiaChi;
            lbPhoneNumber.Text = "SDT:   " + em.SoDT;
            lbTypeAccount.Text = "Loại tài khoản:   " + Login.LoaiTaiKhoan;

            if (Login.LoaiTaiKhoan == "nhanVien")
            {
                btnManagerAccount.Enabled = false;
            }
        }

        #endregion

        
        //Nút quản lí tài khoản
        private void btnManagerAccount_Click(object sender, EventArgs e)
        {
            using (ManagerAccount mna = new ManagerAccount())
            {
                mna.ShowDialog();
            }
        }

        //Nút chỉnh sửa thông tin
        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            using (UpdateInfo udi = new UpdateInfo())
            {
                udi.ShowDialog();
            }
            LoadInfo();
        }


        //Nút làm mới
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadInfo();
        }

        //Nút đổi mật khẩu
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (ChangePassword cp = new ChangePassword())
            {
                cp.ShowDialog();
            }
        }
    }
}
