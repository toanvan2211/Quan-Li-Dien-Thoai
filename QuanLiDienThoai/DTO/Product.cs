using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDienThoai.DTO
{
    public class Product
    {
        #region Attribute

        private string maSanPham;
        private string ten;
        private string thuongHieu;
        private string moTa;
        private int gia;
        private string nhaCungCap;

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

        public string Ten
        {
            get
            {
                return ten;
            }

            set
            {
                ten = value;
            }
        }

        public string ThuongHieu
        {
            get
            {
                return thuongHieu;
            }

            set
            {
                thuongHieu = value;
            }
        }

        public string MoTa
        {
            get
            {
                return moTa;
            }

            set
            {
                moTa = value;
            }
        }

        public int Gia
        {
            get
            {
                return gia;
            }

            set
            {
                gia = value;
            }
        }

        public string NhaCungCap
        {
            get
            {
                return nhaCungCap;
            }

            set
            {
                nhaCungCap = value;
            }
        }

        #endregion

        public Product() { }

        //Hàm dựng với parameter đưa vào là DataRow
        public Product(DataRow row)
        {
            this.MaSanPham = (string)row["maSanPham"];
            this.Ten = (string)row["ten"];
            this.ThuongHieu = (string)row["ThuongHieu"];
            this.Gia = Convert.ToInt32(row["gia"]);
            if(row["nhaCungCap"] != DBNull.Value)
                this.NhaCungCap = (string)row["nhaCungCap"];
            if(row["moTa"] != DBNull.Value)
                this.MoTa = (string)row["moTa"];
        }
    }
}
