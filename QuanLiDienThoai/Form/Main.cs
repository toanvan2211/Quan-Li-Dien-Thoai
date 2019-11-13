using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiDienThoai.Properties;
using QuanLiDienThoai.UC;

namespace QuanLiDienThoai
{
    public partial class Main : Form
    {
        bool isCollapse = true;

        public Main()
        {
            InitializeComponent();
            btnSale_Click(new object(), new EventArgs());
            timerTime.Start();
            LoadPictureBoxTypeAccount();
        }

        void LoadPictureBoxTypeAccount()
        {
            if (Login.LoaiTaiKhoan == "admin")
            {
                ptbTypeAccount.Image = Resources.admin;
                lbTypeAccount.Text = "Tư cách của bạn là Admin";
            }
            else
            {
                ptbTypeAccount.Image = Resources.employees;
                lbTypeAccount.Text = "Tư cách của bạn là Nhân Viên";
            }
        }

        //Thêm userControl vào panel
        private void AddUserControl(UserControl a)
        {
            a.Dock = DockStyle.Fill;
            pnlControls.Controls.Clear();
            pnlControls.Controls.Add(a);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            UC_Sale sale = new UC_Sale();
            AddUserControl(sale);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            UC_Product pd = new UC_Product();
            AddUserControl(pd);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            UC_Inventory st = new UC_Inventory();
            AddUserControl(st);
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            if(Login.LoaiTaiKhoan == "admin")
            {
                UC_Statistical st = new UC_Statistical();
                AddUserControl(st);
            }
            else
            {
                MessageBox.Show("Chỉ admin mới có quyền sử dụng chức năng này!", "Nhằm chỗ rồi em ơi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void BtnInfoAccount_Click(object sender, EventArgs e)
        {
            using (Info inf = new Info())
            {
                inf.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login.User = "";
            Login.LoaiTaiKhoan = "";
            this.Dispose();
        }

        private void btnPhoneNumber_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quản lí Vũ: 076 7103 291\nĐại ca Toàn: 077 8171 871\nHotBoy Trường: 092 5054 086", "Số điện thoại đây nè", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFaceBook_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        void OpenPanel()
        {
            if (isCollapse)
            {
                pnlScroll.Width += 10;
                if (pnlScroll.Size == pnlScroll.MaximumSize)
                {
                    timer1.Stop();
                    isCollapse = false;
                }
            }
            else
            {
                pnlScroll.Width -= 10;
                if(pnlScroll.Size == pnlScroll.MinimumSize)
                {
                    timer1.Stop();
                    isCollapse = true;
                }
            }
        }

        private void ptbVuAdmin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/profile.php?id=100010569428927");
        }

        private void ptbToanAdmin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://fb.com/tonten2211");
        }

        private void ptbTruongAdmin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/dangtruong.nguyen.79");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OpenPanel();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lbTime.Text = dt.ToString("HH:mm:ss");
        }
    }
}
