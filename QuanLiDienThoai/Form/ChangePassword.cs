using QuanLiDienThoai.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiDienThoai
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        //Nút trở về
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Nút xác nhận
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbOldPassword.Text != "" && tbNewPassword.Text != "" && tbNewPassword2.Text != "") // Kiểm tra xem các ô textbox có trống hay không
            {
                if (TaiKhoanDAO.Instance.CheckUserLogin(Login.User, tbOldPassword.Text)) //Kiểm tra xem ô mật khẩu cũ có chính xác hay không
                {
                    if (tbNewPassword.Text == tbNewPassword2.Text) //Kiểm tra mật khẩu mới giống nhau
                    {
                        int result = TaiKhoanDAO.Instance.ChangePassword(Login.User, tbNewPassword.Text); //Trả về số hàng thành công
                        if (result == 1) // =1 là thực hiện thành công
                        {
                            MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK);
                            LoginRememberDAO.Instance.DeleteUser();
                            LoginRememberDAO.Instance.SaveUser(Login.User, tbNewPassword.Text);
                        }

                        // Nếu không thì thông báo lỗi
                        else
                        {
                            MessageBox.Show("Đổi mật khẩu không thành công. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới không khớp. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu cũ. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Lỗi", MessageBoxButtons.OK);
            }
            
        }
    }
}
