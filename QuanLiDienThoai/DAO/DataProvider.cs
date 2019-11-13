using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDienThoai.DAO
{
    public class DataProvider
    {
        // Biến được tao ra dùng để đảm bảo chỉ duy nhất có mình nó tồn tại trong cùng 1 thời điểm
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        public DataProvider() { }

        //Chuỗi kết nối với cơ sở dữ liệu
        private string ConnectionSTR = @"Data Source=.\sqlexpress;Initial Catalog=quanLiDienThoai;Integrated Security=True";

        //Hàm dùng để truy xuất vào cơ sở dữ liệu, thực thi lệnh, và trả về kết quả là một bảng dữ liệu
        public DataTable ExecuteQuery(string command, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connect = new SqlConnection(ConnectionSTR))
            {
                connect.Open();

                SqlCommand cmd = new SqlCommand(command, connect);

                if (parameter != null)
                {
                    string[] listpara = command.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter ap = new SqlDataAdapter(cmd);
                ap.Fill(data);

                connect.Close();
            }
            return data;
        }

        //Hàm dùng để truy xuất vào cơ sở dữ liệu, thực thi lệnh, và trả về kết quả là số hàng thành công
        public int ExecuteNonQuery(string command, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connect = new SqlConnection(ConnectionSTR))
            {
                connect.Open();

                SqlCommand cmd = new SqlCommand(command, connect);

                if (parameter != null)
                {
                    string[] listpara = command.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteNonQuery();

                connect.Close();
            }

            return data;
        }


    }
}
