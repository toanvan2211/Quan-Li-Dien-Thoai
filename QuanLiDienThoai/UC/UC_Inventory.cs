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
    public partial class UC_Inventory : UserControl
    {
        public UC_Inventory()
        {
            InitializeComponent();
            LoadInventory();
        }

        void LoadInventory()
        {
            dgvInventory.DataSource = InventoryDAO.Instance.GetProduct();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (Import ip = new Import())
            {
                ip.ShowDialog();
            }
            LoadInventory();
        }
    }
}
