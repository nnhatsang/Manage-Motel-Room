using _LTGDIT93__01_07.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LTGDIT93__01_07
{
    public partial class FDoiMK : Form
    {
        BUS_ACCOUNT bUS_ACCOUNT;
        BUS_KhachHang bUS_KhachHang;
        public KhachHang k;
        FThongBao ft = new FThongBao();
        public string userName;

        public FDoiMK()
        {
            InitializeComponent();
            bUS_ACCOUNT = new BUS_ACCOUNT();
        }

        public bool Check()
        {
            ACCOUNT ac = bUS_ACCOUNT.GetACCOUNT(this.userName);
            if (txt_MKcu.Text.Trim() == "")
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Vui lòng nhập mật khẩu hiện tại!!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
                reset();
                return false;

            }
            else if (txt_MKMoi.Text.Trim() == "")
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Vui lòng nhập mật khẩu mới!!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
                reset();
                return false;
            }
            else if (txt_XNMatKhau.Text.Trim() == "")
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Vui lòng nhập mật khẩu xác nhận !!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
                reset();
                return false;
            }
            else if (txt_XNMatKhau.Text != txt_MKMoi.Text)
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Mật khẩu mới và xác nhận mật khẩu không trùng nhau!!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
                reset();
                return false;
            }
            else if (ComputeSha256Hash(txt_MKcu.Text).Trim() != (ac.PassWord.Trim()))
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Mật khẩu cũ sai!!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
                reset();
                return false;
            }
            else if (ComputeSha256Hash(txt_MKMoi.Text.Trim()) == ac.PassWord.Trim())
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Mật khẩu mới không được trùng với mât khẩu hiện tại!!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
                reset();
                return false;
            }
            else if (txt_MKMoi.Text.Length <= 6 || txt_MKMoi.Text.Contains(" "))
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Mật khẩu tối thiểu 6 ký tự và không có khoảng trắng!!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
                reset();
                return false;
            }
            return true;
        }
        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                FThongBao f = new FThongBao();
                f.TieuDe = "Xác nhận";
                f.ThongBao = "Bạn chắc thay đổi mặt khẩu đăng nhập?";
                f.n = 1;
                f.ShowDialog();
                int check = 0;
                check = f.check;
                if (check != 1)
                {
                    ACCOUNT a = new ACCOUNT();
                    a.UserName = userName;
                    a.PassWord = ComputeSha256Hash(txt_MKMoi.Text);
                    bUS_ACCOUNT.updatePass(a);
                    ft.TieuDe = "Thông báo";
                    ft.ThongBao = "Đổi mật khẩu thành công";
                    ft.YesT = "OK";
                    ft.n = 0;
                    ft.ShowDialog();
                    this.Close();
                }
            }

        }
        public void reset()
        {
            txt_MKMoi.Text = "";
            txt_MKcu.Text = "";
            txt_XNMatKhau.Text = "";
            txt_MKcu.Focus();
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

       

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (txt_MKcu.PasswordChar == '\0')
            {
                btn_On.BringToFront();
                txt_MKcu.PasswordChar = '*';
                txt_MKMoi.PasswordChar = '*';
                txt_XNMatKhau.PasswordChar = '*';


            }
        }

        private void btn_On_Click(object sender, EventArgs e)
        {
            if (txt_MKcu.PasswordChar == '*')
            {
                btn_Off.BringToFront();
                txt_MKcu.PasswordChar = '\0';
                txt_MKMoi.PasswordChar = '\0';
                txt_XNMatKhau.PasswordChar = '\0';


            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
