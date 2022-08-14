using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _LTGDIT93__01_07.BUS;

namespace _LTGDIT93__01_07
{
    public partial class FChiTietPhongThue : Form
    {
        public String maPhong;
        public int check = 1;
        BUS_NhaTro bUS_NhaTro;
        BUS_Phong bUS_Phong;
        BUS_PhieuThuePhong bUS_PhieuThuePhong;
        BUS_KhachHang bUS_KhachHang;
        Phong p;
        public KhachHang k;
        public FChiTietPhongThue()
        {
            InitializeComponent();
        }

        private void FChiTietPhongThue_Load(object sender, EventArgs e)
        {
            bUS_NhaTro = new BUS_NhaTro();
            bUS_Phong = new BUS_Phong();
            if(check == 0)
            {
                this.btn_Thue.Visible = false;
            }
            bUS_PhieuThuePhong = new BUS_PhieuThuePhong();
            bUS_KhachHang = new BUS_KhachHang();
            p = bUS_Phong.getPhong(maPhong);
            this.txt_LienHe.Text = bUS_KhachHang.GetKhachHangNT(bUS_NhaTro.findNhaTro(p.MaNhaTro).MaChuNha).SDT;
            this.txt_DiaChi.Text = bUS_NhaTro.getDiaChi(p.MaNhaTro);
            this.txt_GiaThue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", p.GiaThue); 
            this.txt_MoTa.Text = p.MoTa;
            this.txt_DienTich.Text = p.DienTich.ToString();
            this.txt_MaPhong.Text = maPhong;
            MemoryStream stream = new MemoryStream(p.Anh.ToArray());
            Image img = Image.FromStream(stream);
            if (img == null)
                return;
            this.pb_Hinh.Image = img;


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
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Thue_Click(object sender, EventArgs e)
        {
            if (bUS_PhieuThuePhong.checkPhieuThue(k.MaKH, maPhong))
            {
                PhieuThuePhong pt = new PhieuThuePhong();
                pt.MaKH = k.MaKH;
                pt.MaPhong = this.maPhong;
                pt.NgapLapPhieu = DateTime.Now;
                pt.TinhTrang = "Chờ xử lý";
                bUS_PhieuThuePhong.addPhieuThuePhong(pt);
                this.LoadThongBaoOk("Thành công", "Yêu cầu thuê thành công!\nVui lòng đợi chủ nhà duyệt yêu cầu của bạn", "Ok");
                this.Close();
            }
            else
            {
                this.LoadThongBaoOk("Thông báo", "Bạn đã gửi yêu cầu!\nVui lòng đợi chủ nhà duyệt yêu cầu của bạn", "Ok");
            }
        }

        private void LoadThongBaoOk(string tieuDe, string thongBao, string YTest)
        {
            FThongBao f = new FThongBao();
            f.TieuDe = tieuDe;
            f.ThongBao = thongBao;
            f.YesT = YTest;
            f.n = 0;
            f.ShowDialog();
        }
    }
}
