using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiDienThoai.DTO;

namespace QuanLiDienThoai.DAO
{
    public class EmloyeesDAO
    {
        //Tương tự DataProvider
        private static EmloyeesDAO instance;

        public static EmloyeesDAO Instance
        {
            get { if (instance == null) instance = new EmloyeesDAO(); return instance; }
            private set { instance = value; }
        }

        //Hàm dựng
        public EmloyeesDAO() { }

        //Lấy tất cả nhân viên trong cơ sở dữ liệu
        public DataTable GetEmloyees()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from nhanvien");
            return data;
        }

        //Tìm kiếm nhân viên theo mã nhân viên
        public Emloyees GetEmloyeesWithID(string id)
        {
            DataRow row = DataProvider.Instance.ExecuteQuery("Select * from nhanvien where maNhanVien = '" + id + "'").Rows[0];
            Emloyees em = new Emloyees(row);
            return em;
        }

        //Kiểm tra nhân viên đã tồn tại trong csdl chưa?
        public bool CheckExistEmloyees(string id)
        {
            bool result = true;
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from nhanvien where manhanvien = '" + id + "'");
            if (data.Rows.Count == 0)
            {
                result = false;
            }
            return result;
        }

        //Thêm nhân viên vào csdl
        public int AddEmloyees(string id, string name, string sex, string address, string phone)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_AddEmloyees @id , @name , @sex , @address , @phonenumber", new object[] { id, name, sex, address, phone });
            return result;
        }

        //Sửa thông tin nhân viên
        public int UpdateEmloyees(string id, string name, string sex, string address, string phonenumber)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_UpdateEmloyees @id , @name , @sex , @address , @phonenumber", new object[] { id, name, sex, address, phonenumber });
            return result;
        }

        //Xóa nhân viên đã có tài khoản, =>> phải xóa tài khoản trước rồi mới được xóa nhân viên
        public int DeleteEmloyeesHaveAccount(string id)
        {
            string username;
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from taikhoan where manhanvien = '" + id + "'");
            username = data.Rows[0]["username"].ToString();
            DataProvider.Instance.ExecuteNonQuery("USP_DeleteAccount @username", new object[] { username });
            int result = DataProvider.Instance.ExecuteNonQuery("USP_DeleteEmloyees @id", new object[] { id });
            return result;
        }

        //Xóa nhân viên 
        public int DeleteEmloyees(string id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_DeleteEmloyees @id", new object[] { id });
            return result;
        }
    }
}
