using _LTGDIT93__01_07.BUS;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LTGDIT93__01_07.GUI
{
    public partial class FTrangChu : Form
    {
        BUS_ACCOUNT bUS_ACCOUNT = new BUS_ACCOUNT();
        public string user;
        BUS_KhachHang bUS_KhachHang;

        UCThongTinKhachHang uC;
        public FTrangChu()
        {
            InitializeComponent();
        }
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 33, b.Location.Y - 40);
            imgSlide.SendToBack();
        }
        private void addUControls(UserControl uc)
        {
            panelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            panelContainer.Controls.Add(uc);
        }
        private void btn_TTKH_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void btn_TTKH_Click(object sender, EventArgs e)
        {
            uC = new UCThongTinKhachHang();
            uC.get = bUS_KhachHang.GetKhachHang(user);
            addUControls(uC);
        }

        private void btn_ChoThueTro_Click(object sender, EventArgs e)
        {

            UCThemTro uC = new UCThemTro();
            uC.k = bUS_KhachHang.GetKhachHang(user);
            addUControls(uC);
        }

        private void FTrangChu_Load(object sender, EventArgs e)
        {
            bUS_KhachHang = new BUS_KhachHang();
            uC = new UCThongTinKhachHang();
            uC.get = bUS_KhachHang.GetKhachHang(user);
            addUControls(uC);
        }

        private void btn_TimTro_Click(object sender, EventArgs e)
        {
            UCTimTro uC = new UCTimTro();
            uC.k = bUS_KhachHang.GetKhachHang(user);
            addUControls(uC);
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            FThongBao f = new FThongBao();
                f.TieuDe = "Xác nhận";
                f.ThongBao = "Bạn chắc chắn muốn thoát?";
                f.n = 1;
                f.ShowDialog();
                int check = 0;
                check = f.check;
                if (check != 1)
            {
                FDangNhap dn = new FDangNhap();
                this.Hide();
                dn.ShowDialog();
                this.Close();
            }
        }
    }
}
