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
    public partial class Login : Form
    {
        public static string User = "";
        public static string LoaiTaiKhoan = "";
        public Login()
        {
            InitializeComponent();
            LoadUserIfRemember(); //Kiểm tra trong bảng 'nhớ mật khẩu' xem có tài khoản hay không, nếu có thì load vào textbox
        }

        #region Method

        //Hàm lưu mật khẩu vào bảng 'nhớ mật khẩu'
        void RememberLogin(string UserName, string PassWord)
        {
            DataTable data = LoginRememberDAO.Instance.GetUser();
            if (data.Rows.Count == 0)
            {
                LoginRememberDAO.Instance.SaveUser(UserName, PassWord);
            }
            else
            {
                LoginRememberDAO.Instance.DeleteUser();
                LoginRememberDAO.Instance.SaveUser(UserName, PassWord);
            }
        }

        //Kiểm tra trong bảng 'nhớ mật khẩu' xem có tài khoản hay không, nếu có thì load vào textbox
        void LoadUserIfRemember()
        {
            DataTable data = LoginRememberDAO.Instance.GetUser();
            if (data.Rows.Count > 0)
            {
                tbUser.Text = data.Rows[0]["username"].ToString();
                tbPassword.Text = data.Rows[0]["matKhau"].ToString();
                cbRemember.CheckState = CheckState.Checked;
            }
        }

        #endregion

        //Nút đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Gán giá trị
            string UserName = tbUser.Text;
            string PassWord = tbPassword.Text;

            if (TaiKhoanDAO.Instance.CheckUserLogin(UserName, PassWord)) //Kiểm tra tính chính xác 
            {
                User = UserName; //Lưu lại biến userName để dùng về sau
                LoaiTaiKhoan = TaiKhoanDAO.Instance.GetTypeAccount(UserName); //Lưu lại biến Loại tài khoản để cấp quyền
                if (cbRemember.Checked) //Kiểm tra xem nút nhớ đăng nhập có checked hay không
                {
                    RememberLogin(UserName, PassWord); // có thì lưu vào csdl
                    try
                    {
                        using (Main m = new Main())
                        {
                            this.Hide();
                            m.ShowDialog();
                            this.Show();
                        }
                    }
                    catch (Exception a)
                    {
                        Application.Exit();
                    }
                }
                else // Không thì thôi
                {
                    using (Main m = new Main())
                    {
                        this.Hide();
                        m.ShowDialog();
                        this.Show();
                    }
                }
            }
            else // Sai mật khẩu hoặc tài khoản thì thông báo
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        //Nút thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //Sự kiện khi thay đổi check ở ô nhớ mật khẩu
        private void cbRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRemember.Checked == false) //Uncheck thì xóa tài khoản trong csdl
            {
                LoginRememberDAO.Instance.DeleteUser();
            }
            else //Checked thì kiểm tra xem có tài khoản nào trong bảng không
            {
                if (LoginRememberDAO.Instance.GetUser().Rows.Count == 0) // Không có
                {
                    if (TaiKhoanDAO.Instance.CheckUserLogin(tbUser.Text, tbPassword.Text)) // Thì kiểm tra tính đúng đắn của thông tin đăng nhập
                    {
                        LoginRememberDAO.Instance.SaveUser(tbUser.Text, tbPassword.Text); //Sau đó lưu tài khoản
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
