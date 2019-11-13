using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDienThoai.DAO
{
    public class LoginRememberDAO
    {
        //Tương tự DataProvider
        private static LoginRememberDAO instance;

        public static LoginRememberDAO Instance
        {
            get { if (instance == null) instance = new LoginRememberDAO(); return instance; }
            private set { instance = value; }
        }

        //Hàm dựng
        public LoginRememberDAO() { }

        //Lưu tài khoản vào csdl =>> dùng để cho chức năng nhớ mật khẩu
        public void SaveUser(string UserName, string PassWord)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_SaveUser @username , @password", new object[] { UserName, PassWord });
        }

        //Trả về tài khoản đang lưu trong csdl
        public DataTable GetUser()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from nhomatkhau");
            return data;
        }

        //Xóa tài khoản
        public void DeleteUser()
        {
            DataProvider.Instance.ExecuteNonQuery("delete from nhoMatKhau");
        }
    }
}
