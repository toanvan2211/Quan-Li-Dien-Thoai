using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDienThoai.DAO
{
    
    public class DetailBillDAO
    {
        //Tương tự DataProvider
        private static DetailBillDAO instance;

        public static DetailBillDAO Instance
        {
            get { if (instance == null) instance = new DetailBillDAO(); return instance; }
            private set { instance = value; }
        }

        //Hàm dựng
        public DetailBillDAO() { }

        //Lấy danh sách chi tiết hóa đơn trong csdl
        public DataTable GetDetailBill()
        {
            return DataProvider.Instance.ExecuteQuery("select * from ChiTietHoaDon");
        }
        
        //Lưu chi tiết hóa đơn vào csdl
        public int SaveDetailBill(int idBill, string idProduct, int Amount)
        {
            return DataProvider.Instance.ExecuteNonQuery("USP_SaveDetailBill @idBill , @idProduct , @Amount", new object[] { idBill, idProduct, Amount});
        }
    }
}
