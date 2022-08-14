using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _LTGDIT93__01_07.BUS;

namespace _LTGDIT93__01_07
{
    public partial class FThongTinKH : Form
    {
        BUS_KhachHang bUS_KhachHang;
        BUS_PhieuThuePhong bUS_PhieuThuePhong;
        public string maPhieu;
        public FThongTinKH()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FThongTinKH_Load(object sender, EventArgs e)
        {
            bUS_KhachHang = new BUS_KhachHang();
            bUS_PhieuThuePhong = new BUS_PhieuThuePhong();
            KhachHang k = bUS_KhachHang.GetKhachHangNT(bUS_PhieuThuePhong.getPhieuThue(maPhieu).MaKH);
            this.txt_TenKH.Text = k.TenKH;
            this.txt_SDT.Text = k.SDT;
            this.txt_MaKH.Text = k.MaKH;
            this.txt_GT.Text = k.GioiTinh;
            this.txt_CMND.Text = k.CMND;
            this.txt_DiaChi.Text = k.DiaChi;
            if (k.Avatar != null)
            {

                MemoryStream stream = new MemoryStream(k.Avatar.ToArray());
                Image img = Image.FromStream(stream);
                if (img == null)
                    return;
                this.pb_avatar.Image = img;
            }
        }
    }
}
