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
    public partial class UC_Product : UserControl
    {
        public UC_Product()
        {
            InitializeComponent();
            LoadProduct();
        }

        void LoadProduct()
        {
            dgvProduct.DataSource = ProductDAO.Instance.GetProduct();
            tbSearch.Text = "";
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProduct.CurrentRow.Selected = true;
            try
            {
                tbIDProduct.Text = dgvProduct.Rows[e.RowIndex].Cells["maSanPham"].FormattedValue.ToString();
                tbName.Text = dgvProduct.Rows[e.RowIndex].Cells["ten"].FormattedValue.ToString();
                tbBranch.Text = dgvProduct.Rows[e.RowIndex].Cells["thuongHieu"].FormattedValue.ToString();
                tbDescription.Text = dgvProduct.Rows[e.RowIndex].Cells["moTa"].FormattedValue.ToString();
                tbSupplier.Text = dgvProduct.Rows[e.RowIndex].Cells["nhaCungCap"].FormattedValue.ToString();
                int a;
                int.TryParse(dgvProduct.Rows[e.RowIndex].Cells["gia"].FormattedValue.ToString(), out a);
                nupPrice.Value = a;
            }
            catch
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ProductDAO.Instance.CheckExistProduct(tbIDProduct.Text) == false)
            {
                if (tbName.Text != "" && tbBranch.Text != "" && tbSupplier.Text != "")
                {
                    int result = ProductDAO.Instance.AddProduct(tbIDProduct.Text, tbName.Text, tbBranch.Text, tbDescription.Text, (int)nupPrice.Value, tbSupplier.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!!", "Thông báo", MessageBoxButtons.OK);
                        LoadProduct();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công!!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Sản phẩm này đã tồn tại", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (ProductDAO.Instance.CheckExistProduct(tbIDProduct.Text))
            {
                if (tbName.Text != "" && tbBranch.Text != "" && tbSupplier.Text != "")
                {
                    int result = ProductDAO.Instance.UpdateProduct(tbIDProduct.Text, tbName.Text, tbBranch.Text, tbDescription.Text, (int)nupPrice.Value, tbSupplier.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công!!", "Thông báo", MessageBoxButtons.OK);
                        LoadProduct();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sản phẩm không thành công!!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Sản phẩm này không tồn tại", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ProductDAO.Instance.CheckExistProduct(tbIDProduct.Text))
            {
                int result = ProductDAO.Instance.DeleteProduct(tbIDProduct.Text);
                if (result == 1)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!!", "Thông báo", MessageBoxButtons.OK);
                    LoadProduct();
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm không thành công!!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Sản phẩm này không tồn tại", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

            DataView dv = new DataView(ProductDAO.Instance.GetProduct());
            dv.RowFilter = string.Format("ten Like '%{0}%'", tbSearch.Text);
            dgvProduct.DataSource = dv;
        }
    }
}
