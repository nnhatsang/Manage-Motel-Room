using _LTGDIT93__01_07.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _LTGDIT93__01_07.BUS;
using System.Security.Cryptography;
using System.Drawing.Imaging;
using _LTGDIT93__01_07.GUI;

namespace _LTGDIT93__01_07
{
    public partial class FDangKyKhachHang : Form
    {
        KhachHang k;
        BUS_ACCOUNT bUS_ACCOUNT;
        BUS_KhachHang bUS_KhachHang;
        private string imgPath;
        FThongBao ft = new FThongBao();
        FTrangChu fc = new FTrangChu();

        public FDangKyKhachHang()
        {
            InitializeComponent();
            cb_GT.Items.Add("Nam");
            cb_GT.Items.Add("Nữ");
            cb_GT.Items.Add("Khác");
            cb_GT.SelectedIndex = 0;
        }



        private void btn_Close_Click(object sender, EventArgs e)
        {
            FDangNhap f = new FDangNhap();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
        private Byte[] converImgToByte(string path)
        {
            try
            {
                FileStream fs;
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                Byte[] picbyte = new byte[fs.Length];
                fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                return picbyte;
            }
            catch
            {
                return null;
            }

        }
        private Image ByteToImg(string byteString)
        {
            try
            {
                Byte[] imgBytes = Convert.FromBase64String(byteString);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                ms.Write(imgBytes, 0, imgBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
            catch (ArgumentException ex)
            {
                return null;
            }
        }

        private void btn_UpLoadImg_Click(object sender, EventArgs e)
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
                    Pb_UpImg.Image = img;
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

        public bool checkFull()
        {

            if (!(string.IsNullOrEmpty(txt_TenKH.Text) || string.IsNullOrEmpty(cb_GT.Text) || string.IsNullOrEmpty(txt_SDT.Text) || string.IsNullOrEmpty(txt_CMND.Text) || string.IsNullOrEmpty(txt_DiaChi.Text) || string.IsNullOrEmpty(txt_Username.Text) || string.IsNullOrEmpty(txt_Password.Text) || string.IsNullOrEmpty(txt_XacNhanPassword.Text)))
            {
                return false;
            }
            return true;
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            if (checkFull())
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Không được để trống thông tin!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();

            }
            else if (txt_Username.Text.Contains(" ") || txt_Username.Text.Contains("@"))
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Tên tài khoản không được có khoảng trắng hoặc có ký tự đặc biệt!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();

            }
            else if (txt_Password.Text != (txt_XacNhanPassword.Text))
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Xác nhận mật khẩu không đúng!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
                this.txt_Password.Text = "";
                this.txt_XacNhanPassword.Text = "";

            }
            else if (txt_Password.Text.Length < 6 || txt_Password.Text.Contains(" "))
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Vui lòng nhập mật khẩu có độ dài ít nhất 6 kì tự và không có khoảng trắng!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
            }
            else
            {
                KhachHang k = new KhachHang();
                ACCOUNT ac = new ACCOUNT();
                k.TenKH = txt_TenKH.Text;
                k.GioiTinh = cb_GT.Text;
                k.SDT = txt_SDT.Text;
                k.CMND = txt_CMND.Text;
                k.DiaChi = txt_DiaChi.Text;
                k.UserName = txt_Username.Text;
                if(Pb_UpImg.Image == null)
                {
                    ft.TieuDe = "Thông báo";
                    ft.ThongBao = "Vui lòng chọn ảnh đại diện!";
                    ft.YesT = "OK";
                    ft.n = 0;
                    ft.ShowDialog();
                    return;
                }

                MemoryStream stream = new MemoryStream();
                Pb_UpImg.Image.Save(stream, ImageFormat.Jpeg);
                k.Avatar = stream.ToArray();
                ac.UserName = txt_Username.Text;
                ac.PassWord = ComputeSha256Hash(txt_Password.Text);
                int kq = bUS_KhachHang.AddKhachHang(k, ac);
                if (kq == 1)
                {
                    ft.TieuDe = "Thông báo";
                    ft.ThongBao = "Đăng ký thành công!";
                    ft.YesT = "OK";
                    ft.n = 0;
                    ft.ShowDialog();
                    reset();
                    FTrangChu f = new FTrangChu();
                    f.user = k.UserName;
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                else if (kq == 0)
                {
                    ft.TieuDe = "Thông báo";
                    ft.ThongBao = "Tài khoản này đã tồn tại!";
                    ft.YesT = "OK";
                    ft.n = 0;
                    ft.ShowDialog();
                }
                else
                {
                    ft.TieuDe = "Thông báo";
                    ft.ThongBao = "Thêm khách hàng thất bại!!";
                    ft.YesT = "OK";
                    ft.n = 0;
                    ft.ShowDialog();
                }
            }
        }


        public void reset()
        {
            bUS_KhachHang = new BUS_KhachHang();
            this.txt_CMND.Text = "";
            this.txt_TenKH.Text = "";
            this.cb_GT.Text = "";
            this.txt_SDT.Text = "";
            this.txt_Username.Text = "";
            this.txt_Password.Text = "";
            this.txt_XacNhanPassword.Text = "";
            this.txt_TenKH.Focus();

        }

        private void FDangKyKhachHang_Load(object sender, EventArgs e)
        {
            bUS_KhachHang = new BUS_KhachHang();

        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }

        private void btn_onpass_Click(object sender, EventArgs e)
        {
            if (txt_Password.PasswordChar == '*')
            {
                btn_off.BringToFront();
                txt_Password.PasswordChar = '\0';
                txt_XacNhanPassword.PasswordChar = '\0';

            }
        }

        private void btn_offpass_Click(object sender, EventArgs e)
        {
            if (txt_Password.PasswordChar == '\0')
            {
                btn_on.BringToFront();
                txt_Password.PasswordChar = '*';
                txt_XacNhanPassword.PasswordChar = '*';

            }
        }



        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Không được ký tự khác ngoài số!!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
            }

        }

        private void txt_TenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Tên khách hàng không có ký tự đặc biệt!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
            }
        }

        private void txt_CMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Không được ký tự khác ngoài số!!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (txt_Password.PasswordChar == '*')
            {
                btn_off.BringToFront();
                txt_Password.PasswordChar = '\0';
                txt_XacNhanPassword.PasswordChar = '\0';

            }
        }

        private void btn_off_Click(object sender, EventArgs e)
        {
            if (txt_Password.PasswordChar == '\0')
            {
                btn_on.BringToFront();
                txt_Password.PasswordChar = '*';
                txt_XacNhanPassword.PasswordChar = '*';

            }
        }
    }
}
