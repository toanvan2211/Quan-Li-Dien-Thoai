using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDienThoai.DAO
{
    public class TaiKhoanDAO
    {
        //Tương tự DataProvider

        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            private set { instance = value; }
        }

        //Hàm dựng rỗng
        public TaiKhoanDAO() { }

        //Kiểm tra thông tin đăng nhập, trả về kiểu bool
        public bool CheckUserLogin(string UserName, string PassWord)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_Login @username , @password", new object[] { UserName, PassWord });
            return data.Rows.Count > 0;
        }

        //Lấy loại tài khoản theo username
        public string GetTypeAccount(string UserName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from taikhoan where username = '" + UserName + "'");
            return data.Rows[0]["loaiTaikhoan"].ToString();
        }

        //Đổi mật khẩu
        public int ChangePassword(string UserName, string NewPassword)
        {
            return DataProvider.Instance.ExecuteNonQuery("USP_ChangePassword @username , @newpassword", new object[] { UserName, NewPassword });
        }

        //Lấy danh sách tài khoản
        public DataTable GetAccount()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from taikhoan");
            return data;
        }

        //Kiểm tra tồn tại
        public bool CheckExistAccount(string UserName)
        {
            bool result = true;
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from taikhoan where username = '" + UserName + "'");
            if (data.Rows.Count == 0)
            {
                result = false;
            }
            return result;
        }

        //Thêm tài khoản (tạo mới tài khoản)
        public int AddAccount(string UserName, string Password, string AccountType, string IDEmloyees)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_AddAccount @Username , @Password , @AccountType , @IDemloyees", new object[] { UserName, Password, AccountType, IDEmloyees });
            return result;
        }

        //Chỉnh sửa thông tin tài khoản
        public int UpdateAccount(string UserName, string Password, string AccountType)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_UpdateAccount @Username , @Password , @asd", new object[] { UserName, Password, AccountType });
            return result;
        }

        //Xóa tài khoản
        public int DeleteAccount(string UserName)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_DeleteAccount @Username", new object[] { UserName});
            return result;
        }

        //Lấy mã nhân viên theo username
        public string GetID(string user)
        {
            string id;
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from taikhoan where username = '" + user + "'");
            id = (string)data.Rows[0]["maNhanVien"];
            return id;
        }
    }
}
