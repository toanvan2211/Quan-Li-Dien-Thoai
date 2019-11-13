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
    public partial class Info : Form
    {
        public Info()
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

        private void BtnManagerAccount_Click(object sender, EventArgs e)
        {

            using (ManagerAccount mna = new ManagerAccount())
            {
                mna.ShowDialog();
            }
        }

        private void BtnUpdateInfo_Click(object sender, EventArgs e)
        {
            using (UpdateInfo udi = new UpdateInfo())
            {
                udi.ShowDialog();
            }
            LoadInfo();
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            using (ChangePassword cp = new ChangePassword())
            {
                cp.ShowDialog();
            }
        }

        private void BtnRefesh_Click(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
