using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _LTGDIT93__01_07.BUS;
namespace _LTGDIT93__01_07
{
    public partial class FThemTro : Form
    {

        BUS_NhaTro bUS_NhaTro;
        public KhachHang k;
        public FThemTro()
        {
            InitializeComponent();
        }
        public void reset()
        {
            bUS_NhaTro = new BUS_NhaTro();
            this.txt_DiaChi.Text = "";
            this.txt_QuanHuyen.Text = "";
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
        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (txt_DiaChi.Text.Trim() == "")
            {
                this.LoadThongBaoOk("Thông báo", "Vui lòng nhập địa chỉ", "Ok");
                return;
            }
            NhaTro n = new NhaTro();
            n.Quan = txt_QuanHuyen.Text;
            n.DiaChi = txt_DiaChi.Text;
            n.TinhTrang = "Đang kinh doanh";
            n.SoLuongPhong = 0;
            n.MaChuNha = k.MaKH;
            int KQ = bUS_NhaTro.AddNhaTro(n);
            if (KQ == 0)
            {
                MessageBox.Show("Nhà trọ đã tồn tại!");
            }
            else if (KQ == 1)
            {
                MessageBox.Show("Thêm nhà trọ thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhà trọ không thành công!");
            }
            reset();
        }

        private void FThemTro_Load(object sender, EventArgs e)
        {
            bUS_NhaTro = new BUS_NhaTro();
            txt_QuanHuyen.SelectedIndex = 0;
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_QuanHuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

