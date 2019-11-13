using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDienThoai.DAO
{
    public class BillDAO
    {
        //Tương tự DataProvider
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set { instance = value; }
        }

        //Hàm dựng
        public BillDAO() { }


        //Lấy danh sách hóa đơn trong csdl
        public DataTable GetBill()
        {
            return DataProvider.Instance.ExecuteQuery("Select * from HoaDon");
        }

        //Lưu hóa đơn
        public int SaveBill(string idEmloyees, DateTime Day, decimal TotalCash)
        {
            return DataProvider.Instance.ExecuteNonQuery("USP_SaveBill @idEmloyees , @Day , @TotalCash", new object[] { idEmloyees, Day, TotalCash });
        }

        //Lấy mã hóa đơn theo giờ tương ứng
        public int GetIDBillByDateTime(DateTime time)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from hoadon where ngaylap = '" + time.ToString() + "'");
            return (int)data.Rows[0]["maHoaDon"];
        }
    }
}
