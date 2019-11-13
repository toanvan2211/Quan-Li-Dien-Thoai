using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiDienThoai.DAO;

namespace QuanLiDienThoai.UC
{
    public partial class UC_Statistical : UserControl
    {
        public UC_Statistical()
        {
            InitializeComponent();
            LoadBill();
            CalculateRevenue();
        }

        void LoadBill()
        {
            dgvBill.DataSource = BillDAO.Instance.GetBill();
        }

        void CalculateRevenue()
        {
            decimal Revenue = 0;
            DataTable data = dgvBill.DataSource as DataTable;
            foreach (DataRow item in data.Rows)
            {
                Revenue += Convert.ToDecimal(item["tongtien"]);
            }

            string T = String.Format("{0:#,# vnđ}", Revenue);
            tbRevenue.Text = T;
        }
    }
}
