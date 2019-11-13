using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace QuanLiDienThoai.DTO
{
    public class DetailBill
    {
        #region Attribute
        private string maSanPham;
        private decimal soLuong;

        public string MaSanPham
        {
            get
            {
                return maSanPham;
            }

            set
            {
                maSanPham = value;
            }
        }

        public decimal SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        #endregion

        public DetailBill() { }
        
    }
}
