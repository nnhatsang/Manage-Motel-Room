using _LTGDIT93__01_07.BUS;
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

namespace _LTGDIT93__01_07.GUI
{
    public partial class UCThongTinKhachHang : UserControl
    {


        BUS_KhachHang bUS_KhachHang;
        public string userTTKH;
        public KhachHang get;
        public UCThongTinKhachHang()
        {
            InitializeComponent();

        }
        private void UCThongTinKhachHang_Load(object sender, EventArgs e)
        {
            this.txt_Username.Text = get.UserName;
            this.txt_MaKH.Text = get.MaKH;
            this.txt_GioiTinh.Text = get.GioiTinh;
            this.txt_CMND.Text = get.CMND;
            this.txt_DiaChi.Text = get.DiaChi;
            this.txt_SDT.Text = get.SDT;
            this.txt_TenKH.Text = get.TenKH;
            if(get.Avatar != null)
            {

                MemoryStream stream = new MemoryStream(get.Avatar.ToArray());
                Image img = Image.FromStream(stream);
                if (img == null)
                    return;
                this.pb_avatar.Image = img;
            }



        }
        private Image ByteToImg(string byteString)
        {
            try
            {
                byte[] imgBytes = Convert.FromBase64String(byteString);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                ms.Write(imgBytes, 0, imgBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
        }
        private void btn_DSYeuCau_Click(object sender, EventArgs e)
        {
            FYeuCauThuePhong f = new FYeuCauThuePhong();
            f.k = this.get;
            f.check = 1;
            this.Parent.Parent.Hide();
            f.ShowDialog();
            f = null;
            this.Parent.Parent.Show();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            FLichSuThueTro f = new FLichSuThueTro();
            f.maKH = get.MaKH;
            this.Parent.Parent.Hide();
            f.ShowDialog();
            f = null;
            this.Parent.Parent.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            FDoiMK f = new FDoiMK();
            f.userName = get.UserName;
            f.ShowDialog();
        }
    }
}
