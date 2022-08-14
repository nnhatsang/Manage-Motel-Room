using _LTGDIT93__01_07.BUS;
using _LTGDIT93__01_07.GUI;
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
    public partial class FDangNhap : Form
    {
        BUS_ACCOUNT bUS_ACCOUNT;
        BUS_KhachHang bUS_KhachHang;
        public KhachHang t;
        public string userName;
        FThongBao ft = new FThongBao();
        public FDangNhap()
        {
            InitializeComponent();
            bUS_ACCOUNT = new BUS_ACCOUNT();
            bUS_KhachHang = new BUS_KhachHang();
        }


        private void btn_HienMatKhau_Click(object sender, EventArgs e)
        {
            if (txt_Password.PasswordChar == '\0')
            {
                btn_onpass.BringToFront();
                txt_Password.PasswordChar = '*';
            }

        }

        private void btn_onpass_Click(object sender, EventArgs e)
        {
            if (txt_Password.PasswordChar == '*')
            {
                btn_HienMatKhau.BringToFront();
                txt_Password.PasswordChar = '\0';
            }
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            FDangKyKhachHang f = new FDangKyKhachHang();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void lbl_reset_Click(object sender, EventArgs e)
        {
            txt_UserName.Clear();
            txt_Password.Clear();
            txt_UserName.Focus();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {

            ACCOUNT a = new ACCOUNT();
            if (txt_UserName.Text.Trim() == "" || txt_Password.Text.Trim() == "")
            {
                //MessageBox.Show("Chưa nhập đủ thông tin đăng nhập!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Chưa nhập đủ thông tin đăng nhập!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
                return;

            }
            else
            {
                a.UserName = txt_UserName.Text;
                a.PassWord = ComputeSha256Hash(txt_Password.Text);
            }
            if (bUS_ACCOUNT.checkACCOUNT(a) == 1)
            {
                FTrangChu f = new FTrangChu();
                f.user = this.txt_UserName.Text;
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                ft.TieuDe = "Thông báo";
                ft.ThongBao = "Sai tài khoản hoặc mật khẩu!!";
                ft.YesT = "OK";
                ft.n = 0;
                ft.ShowDialog();
            }
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




    }
}

