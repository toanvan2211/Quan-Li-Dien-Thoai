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
using QuanLiDienThoai.DTO;

namespace QuanLiDienThoai.UC
{
    public partial class UC_Sale : UserControl
    {
        //Tạo ra một datatable để lưu danh sách các sản phẩm khi lập hóa đơn
        DataTable data = new DataTable("Sales");
        decimal totalCash = 0; //Tổng tiền hóa đơn

        public UC_Sale()
        {
            InitializeComponent();

            //Add Cột vào DataTable
            data.Columns.Add(new DataColumn("Mã sản phẩm", typeof(string)));
            data.Columns.Add(new DataColumn("Tên", typeof(string)));
            data.Columns.Add(new DataColumn("Số lượng", typeof(int)));
            data.Columns.Add(new DataColumn("Đơn giá", typeof(int)));
            data.PrimaryKey = new DataColumn[] { data.Columns["Mã sản phẩm"] };

            LoadSaleList();
            LoadProduct();
        }

        //Load danh sách sản phẩm trong datatable (refesh)
        void LoadSaleList()
        {
            dgvListSale.DataSource = null;
            dgvListSale.DataSource = data;
            totalCash = 0;

            foreach (DataRow item in data.Rows)
            {
                decimal donGia = Convert.ToDecimal((int)item["Đơn giá"]);
                decimal soLuong = Convert.ToDecimal((int)item["Số lượng"]);
                totalCash += donGia * soLuong;
            }

            string T;
            T = String.Format("{0:#,# vnđ}", totalCash); //Format kiểu dự liệu tiền
            lbTotalCash.Text = "Tổng tiển:   " + T; //Hiển thị tổng tiền
        }

        //Load danh sách sản phẩm có trong csdl
        void LoadProduct()
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

            string[] postSource1 = data.AsEnumerable().Select<System.Data.DataRow, String>(x => x.Field<String>("ten")).ToArray();

            var source1 = new AutoCompleteStringCollection();
            source1.AddRange(postSource1);
            cbNameProduct.AutoCompleteCustomSource = source1;
            cbNameProduct.DataSource = source1;
        }

        //Nút thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ProductDAO.Instance.CheckExistProduct(cbIDProduct.Text))
            {
                DataRow row = ProductDAO.Instance.GetProductByID(cbIDProduct.Text);
                Product pd = new Product(row);
                if (!data.AsEnumerable().Any(Rows => cbIDProduct.Text == Rows.Field<String>("Mã sản phẩm")))
                {
                    data.Rows.Add(pd.MaSanPham, pd.Ten, Convert.ToInt32(nupAmount.Value), pd.Gia);
                    LoadSaleList();
                }
                else
                {
                    data.Rows.Find(cbIDProduct.Text).SetField("Số lượng", data.Rows.Find(cbIDProduct.Text).Field<int>(2) + (int)nupAmount.Value);
                    data.Rows.Find(cbIDProduct.Text).SetField("Đơn giá", pd.Gia);
                    LoadSaleList();
                }
            }
            else
            {
                MessageBox.Show("Sản phẩm không tồn tại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        //Nút xóa
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (ProductDAO.Instance.CheckExistProduct(cbIDProduct.Text))
            {
                DataRow row = ProductDAO.Instance.GetProductByID(cbIDProduct.Text);
                Product pd = new Product(row);
                if (data.AsEnumerable().Any(Rows => cbIDProduct.Text == Rows.Field<string>("Mã sản phẩm")))
                {
                    if((int)nupAmount.Value <= data.Rows.Find(cbIDProduct.Text).Field<int>(2))
                    {
                        data.Rows.Find(cbIDProduct.Text).SetField("Số lượng", data.Rows.Find(cbIDProduct.Text).Field<int>(2) - (int)nupAmount.Value);
                        data.Rows.Find(cbIDProduct.Text).SetField("Đơn giá", pd.Gia);
                        if(data.Rows.Find(cbIDProduct.Text).Field<int>(2) == 0)
                        {
                            data.Rows.Remove(data.Rows[data.Rows.IndexOf(data.Rows.Find(cbIDProduct.Text))]);
                        }
                        LoadSaleList();
                    }
                    else
                    {
                        MessageBox.Show("Không được xóa quá số lượng tồn tại trong hóa đơn!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tồn tại trong hóa đơn!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Sản phẩm không tồn tại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        //Đồng nhất giữa hai comboBox id và tên sản phẩm
        private void cbIDProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRow row = ProductDAO.Instance.GetProductByID(cbIDProduct.Text);
            Product pd = new Product(row);
            cbNameProduct.SelectedItem = pd.Ten;
        }

        private void cbNameProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRow row = ProductDAO.Instance.GetProductByName(cbNameProduct.Text);
            Product pd = new Product(row);
            cbIDProduct.SelectedItem = pd.MaSanPham;
        }

        //nút hoàn thành (lưu hóa đơn và chi tiết hóa đơn vào csdl)
        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (data.Rows.Count > 0)
            {
                DateTime time = DateTime.Now;
                string IDEmloyees = TaiKhoanDAO.Instance.GetID(Login.User);

                int resultBill = BillDAO.Instance.SaveBill(IDEmloyees, time, totalCash);
                int idBill = BillDAO.Instance.GetIDBillByDateTime(time);

                foreach (DataRow item in data.Rows)
                {
                    DetailBillDAO.Instance.SaveDetailBill(idBill, (string)item["Mã sản phẩm"], (int)item["Số lượng"]);
                }
                
                if (resultBill == 1)
                {
                    MessageBox.Show("Đã lưu hóa đơn!", "Thông báo", MessageBoxButtons.OK);
                    data.Rows.Clear();
                    LoadSaleList();
                }
                else
                {
                    MessageBox.Show("Một số thông tin không đúng vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào để thanh toán!", "Thông báo", MessageBoxButtons.OK);
            }
        }
        //Sự kiến click trên datagridview
        private void dgvListSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvListSale.CurrentRow.Selected = true;
            try
            {
                if (dgvListSale.Rows[e.RowIndex].Cells["Mã sản phẩm"].FormattedValue.ToString() != "")
                {
                    cbIDProduct.Text = dgvListSale.Rows[e.RowIndex].Cells["Mã sản phẩm"].FormattedValue.ToString();
                }
            }
            catch { }
        }
    }
}
