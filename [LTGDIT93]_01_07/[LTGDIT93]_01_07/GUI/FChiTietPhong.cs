using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _LTGDIT93__01_07.BUS;
using System.IO;
using System.Drawing.Imaging;

namespace _LTGDIT93__01_07
{
    public partial class FChiTietPhong : Form
    {
        public string maPhong;
        BUS_Phong bUS_Phong;
        BUS_NhaTro bUS_NhaTro;
        BUS_PhieuThuePhong bUS_PhieuThuePhong;
        Phong p;
        public int check;
        public string imgPath;
        public FChiTietPhong()
        {
            InitializeComponent();
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
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_DienTich.Text.Trim() == "" || txt_GiaThue.Text.Trim() == "" || txt_MoTa.Text.Trim() == "" || pb_Anh.Image == null)
            {
                this.LoadThongBaoOk("Thông báo", "Vui lòng nhập dữ liệu", "Ok");
                return;
            }
            Phong p = bUS_Phong.getPhong(maPhong);
            MemoryStream stream = new MemoryStream();
            pb_Anh.Image.Save(stream, ImageFormat.Jpeg);
            try
            {
                p.DienTich = float.Parse(txt_DienTich.Text);
            }
            catch (Exception ex)
            {
                this.LoadThongBaoOk("Thông báo", "Xin nhập số nguyên hoặc số thập phân", "Ok");
                return;
            }
            p.GiaThue = decimal.Parse(txt_GiaThue.Text);
            p.TinhTrang = txt_TinhTrang.Text;
            p.MoTa = txt_MoTa.Text;
            p.Anh = stream.ToArray();
            int kq = bUS_Phong.updatePhong(p);
            if (kq == 0)
                this.LoadThongBaoOk("Thông báo", "Không có phòng này trong nhà trọ!", "Ok");
            else if (kq == 1)
            {
                this.LoadThongBaoOk("Thông báo", "Cập nhật phòng thành công!", "Ok");
                this.Close();
            }
            else
                this.LoadThongBaoOk("Thông báo", "Cập nhật phòng không thành công!", "Ok");
        }
        private byte[] converImgToByte(String path)
        {
            FileStream fs;
            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }
        //lấy ảnh lên từ database
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
        private void pb_Anh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string selectedPath = null;
            var t = new Thread((ThreadStart)(() =>
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                openFile.RestoreDirectory = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(openFile.FileName);
                    pb_Anh.Image = img;
                    selectedPath = openFile.FileName;
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        private void FChiTietPhong_Load(object sender, EventArgs e)
        {
            bUS_NhaTro = new BUS_NhaTro();
            bUS_Phong = new BUS_Phong();
            bUS_PhieuThuePhong = new BUS_PhieuThuePhong();
            Phong p = bUS_Phong.getPhong(maPhong);
            if (p.TinhTrang != "Ngừng kinh doanh" || check == 0)
                this.btn_KhoiPhuc.Visible = false;
            if (p.TinhTrang == "Đang được thuê")
            {
                this.btn_TTKH.Visible = true;
                this.btn_NgungThue.Visible = true;
            }
            MemoryStream stream = new MemoryStream(p.Anh.ToArray());
            Image img = Image.FromStream(stream);
            if (img == null)
                return;
            this.pb_Anh.Image = img;
            this.txt_MaPhong.Text = this.maPhong;
            this.txt_DiaChi.Text = bUS_NhaTro.getDiaChi(p.MaNhaTro);
            this.txt_GiaThue.Text = p.GiaThue.ToString();
            this.txt_MoTa.Text = p.MoTa;
            this.txt_DienTich.Text = p.DienTich.ToString();
            this.txt_MaPhong.Text = p.MaPhong;
            this.txt_TinhTrang.Text = p.TinhTrang;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            if (txt_DienTich.Text.Trim() == "" || txt_GiaThue.Text.Trim() == "" || txt_MoTa.Text.Trim() == "" || pb_Anh.Image == null)
            {
                this.LoadThongBaoOk("Thông báo", "Vui lòng nhập dữ liệu", "Ok");
                return;
            }
            Phong p = bUS_Phong.getPhong(maPhong);
            MemoryStream stream = new MemoryStream();
            pb_Anh.Image.Save(stream, ImageFormat.Jpeg);
            try
            {
                p.DienTich = float.Parse(txt_DienTich.Text);
            }
            catch (Exception ex)
            {
                this.LoadThongBaoOk("Thông báo", "Xin nhập số nguyên hoặc số thập phân", "Ok");
                return;
            }
            p.GiaThue = decimal.Parse(txt_GiaThue.Text);
            p.TinhTrang = "Trống";
            p.MoTa = txt_MoTa.Text;
            p.Anh = stream.ToArray();
            bUS_Phong.updatePhong(p);
            this.LoadThongBaoOk("Thông báo", "Khôi phục thành công!", "Ok");
            this.Close();
        }

        private void txt_GiaThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            FThongBao f = new FThongBao();
            f.TieuDe = "Xác nhận";
            f.ThongBao = "Bạn muốn dừng cho thuê thuê trọ này?";
            f.n = 1;
            f.ShowDialog();
            int check = 0;
            check = f.check;
            if (check != 1)
            {
                bUS_PhieuThuePhong.dungThuePhong(bUS_PhieuThuePhong.getMaPhieu(maPhong));
                f = new FThongBao();
                f.TieuDe = "Thành công";
                f.ThongBao = "Ngừng cho thuê thành công!";
                f.YesT = "OK";
                f.n = 0;
                f.ShowDialog();
                this.Close();
            }
        }

        private void btn_TTKH_Click(object sender, EventArgs e)
        {
            FThongTinKH f = new FThongTinKH();
            f.maPhieu = bUS_PhieuThuePhong.getMaPhieu(maPhong);
            f.ShowDialog();
        }
    }
}
