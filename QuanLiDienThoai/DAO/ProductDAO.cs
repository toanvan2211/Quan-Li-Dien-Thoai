using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDienThoai.DAO
{
    public class ProductDAO
    {
        //Tương tự DataProvider
        private static ProductDAO instance;
        public static ProductDAO Instance
        {
            get { if (instance == null) instance = new ProductDAO(); return instance; }
            private set { instance = value; }
        }

        //Hàm dựng
        public ProductDAO() { }

        //Lấy danh sách điện thoại có trong csdl
        public DataTable GetProduct()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from dienthoai");
            return data;
        }

        //Lấy điện thoại theo mã
        public DataRow GetProductByID(string id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from dienthoai where maSanPham = '" + id + "'");
            return data.Rows[0];
        }

        //Lấy điện thoại theo tên sản phẩm
        public DataRow GetProductByName(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from dienthoai where ten = '" + name + "'");
            return data.Rows[0];
        }

        //Kiểm tra tồn tại
        public bool CheckExistProduct(string idProduct)
        {
            bool result = true;
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dienthoai where maSanPham = '" + idProduct + "'");
            if (data.Rows.Count == 0)
            {
                result = false;
            }
            return result;
        }

        //Thêm điện thoại
        public int AddProduct(string idProduct, string name, string branch, string description, int price, string supplier)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_AddProduct @idproduct , @name , @branch , @description , @price , @supplier", new object[] { idProduct, name, branch, description, price, supplier });
            return result;
        }

        //Chỉnh sửa thông tin
        public int UpdateProduct(string idProduct, string name, string branch, string description, int price, string supplier)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_UpdateProduct @idproduct , @name , @branch , @description , @price , @supplier", new object[] { idProduct, name, branch, description, price, supplier });
            return result;
        }

        //Xóa điện thoại
        public int DeleteProduct(string idProduct)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_DeleteProduct @idproduct", new object[] { idProduct });
            return result;
        }
    }
}
