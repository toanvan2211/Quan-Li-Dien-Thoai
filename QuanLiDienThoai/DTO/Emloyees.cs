using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDienThoai.DTO
{
    public class Emloyees
    {
        #region Attribute

        private string maNhanVien;
        private string ten;
        private string gioiTinh;
        private string diaChi;
        private string soDT;

        public string MaNhanVien
        {
            get
            {
                return maNhanVien;
            }

            set
            {
                maNhanVien = value;
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

        public string GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string SoDT
        {
            get
            {
                return soDT;
            }

            set
            {
                soDT = value;
            }
        }

        #endregion
        public Emloyees() { }

        //Hàm dựng với parameter đưa vào là DataRow
        public Emloyees(DataRow row)
        {
            MaNhanVien = (string)row["maNhanVien"];
            Ten = (string)row["Ten"];
            if (row["DiaChi"] != DBNull.Value)
                DiaChi = (string)row["DiaChi"];
            if (row["sdt"] != DBNull.Value)
                SoDT = (string)row["sdt"];
            if (Convert.ToInt32(row["gioitinh"]) == 1)
                GioiTinh = "Nam";
            else if (Convert.ToInt32(row["gioitinh"]) == 2)
                GioiTinh = "Nữ";
        }
    }
}
