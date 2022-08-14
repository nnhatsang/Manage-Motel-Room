using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _LTGDIT93__01_07.BUS;

namespace _LTGDIT93__01_07
{
    public partial class FThemPhong : Form
    {
        BUS_Phong bUS_Phong;
        BUS_NhaTro bUS_NhaTro;
        Phong p;
        public string imgPath;
        public string maNhaTro;
        public FThemPhong()
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
        public void reset()
        {
            bUS_Phong = new BUS_Phong();
            this.txt_MoTa.Text = "";
            this.txt_DienTich.Text = "";
            this.txt_GiaThue.Text = "";
            pb_Anh.Image = null;
        }


        //Thêm ảnh
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
        //chọn ảnh trong ổ đĩa
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
                if (selectedPath != null)
                {
                    this.imgPath = Convert.ToBase64String(converImgToByte(selectedPath));
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        private void btn_XacNhan_Click_1(object sender, EventArgs e)
        {
            if (txt_DienTich.Text.Trim() == "" || txt_GiaThue.Text.Trim() == "" || txt_MoTa.Text.Trim() == "" || pb_Anh.Image == null)
            {
                this.LoadThongBaoOk("Thông báo", "Vui lòng nhập dữ liệu", "Ok");
                return;
            }
            Phong p1 = new Phong();
            MemoryStream stream = new MemoryStream();
            pb_Anh.Image.Save(stream, ImageFormat.Jpeg);
            p1.MoTa = txt_MoTa.Text;
            p1.MaNhaTro = maNhaTro;
            try
            {
                p1.DienTich = float.Parse(txt_DienTich.Text);
            }
            catch (Exception ex)
            {
                this.LoadThongBaoOk("Thông báo", "Xin nhập số nguyên hoặc số thập phân", "Ok");
                return;
            }
            p1.GiaThue = int.Parse(txt_GiaThue.Text);
            p1.TinhTrang = "Trống";
            p1.Anh = stream.ToArray();
            int kq = bUS_Phong.AddPhong(p1);
            if (kq == 1)
                MessageBox.Show("Phòng này đã được thêm thành công!");
            else
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
            reset();


        }

        private void FThemPhong_Load_1(object sender, EventArgs e)
        {
            bUS_Phong = new BUS_Phong();
            bUS_NhaTro = new BUS_NhaTro();
            this.txt_MaTro.Text = maNhaTro; //nhận
        }

        private void btn_QuayLai_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_GiaThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}