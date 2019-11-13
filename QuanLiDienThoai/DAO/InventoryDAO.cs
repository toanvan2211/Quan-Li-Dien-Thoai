using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDienThoai.DAO
{
    public class InventoryDAO
    {
        private static InventoryDAO instance;
        public static InventoryDAO Instance
        {
            get { if (instance == null) instance = new InventoryDAO(); return instance; }
            private set { instance = value; }
        }

        public InventoryDAO() { }
        
        public DataTable GetProduct()
        {
            return DataProvider.Instance.ExecuteQuery("Select * from kho");
        }

        public bool CheckExistProduct(string ID)
        {
            bool Exist = false;
            string command = "select * from Kho where masanpham = '" + ID + "'";
            if (DataProvider.Instance.ExecuteQuery(command).Rows.Count > 0)
            {
                Exist = true;
            }
            return Exist;
        }

        public int ImportProduct(string ID, int Ammount)
        {
            return DataProvider.Instance.ExecuteNonQuery("Insert into kho values('" + ID + "', " + Ammount + ", default, default)");
        }
    }
}
