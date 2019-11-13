using QuanLiDienThoai.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiDienThoai
{
    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
            LoadIDProduct();
        }

        void LoadIDProduct()
        {
            DataTable data = ProductDAO.Instance.GetProduct();

            string[] postSource = data
                    .AsEnumerable()
                    .Select<System.Data.DataRow, String>(x => x.Field<String>("maSanPham"))
                    .ToArray();

            var source = new AutoCompleteStringCollection();
            source.AddRange(postSource);
            cbIDProduct.AutoCompleteCustomSource = source;
            cbIDProduct.DataSource = source;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            int result = InventoryDAO.Instance.ImportProduct(cbIDProduct.Text, Convert.ToInt32(nupAmmount.Value));
        }
    }
}
