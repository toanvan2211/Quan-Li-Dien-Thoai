using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDienThoai.DTO
{
    public class Inventory
    {
        private string maSanPham;
        private int soLuong;
        private string trangThai;

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

        public int SoLuong
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

        public string TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }
    }
}
