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
using _LTGDIT93__01_07.GUI;
using Microsoft.Reporting.WinForms;

namespace _LTGDIT93__01_07
{
    public partial class FYeuCauThuePhong : Form
    {
        public KhachHang k;
        public int check;
        public bool checkDialog = false;
        BUS_PhieuThuePhong bUS_PhieuThuePhong;
        public FYeuCauThuePhong()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FYeuCauThuePhong_Load(object sender, EventArgs e)
        {
            bUS_PhieuThuePhong = new BUS_PhieuThuePhong();
            if(this.check == 1)
            {
                gp_main.Text = "Danh sách yêu cầu của bạn";
                btn_ChiTiet.Visible = false;
                btn_XacNhan.Visible = false;
                this.dgv_NhaTro.DataSource = bUS_PhieuThuePhong.ListPhieuThuePhongKH(k.MaKH);
                this.dgv_NhaTro.Columns[1].Visible = false;
                this.dgv_NhaTro.Columns[4].Visible = false;
                this.dgv_NhaTro.Columns[5].Visible = false;
                this.dgv_NhaTro.Columns[7].Visible = false;
                this.dgv_NhaTro.Columns[8].Visible = false;
                dgv_NhaTro.Columns[0].HeaderText = "Mã phiếu";
                dgv_NhaTro.Columns[2].HeaderText = "Mã phòng";
                dgv_NhaTro.Columns[3].HeaderText = "Ngày lập";
                dgv_NhaTro.Columns[6].HeaderText = "Tình trạng";
                dgv_NhaTro.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_NhaTro.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_NhaTro.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_NhaTro.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_NhaTro.Columns[0].Width = (int)(dgv_NhaTro.Width * 0.17);
                dgv_NhaTro.Columns[2].Width = (int)(dgv_NhaTro.Width * 0.17);
                dgv_NhaTro.Columns[3].Width = (int)(dgv_NhaTro.Width * 0.30);
                dgv_NhaTro.Columns[6].Width = (int)(dgv_NhaTro.Width * 0.30);
            }
            else
            {
                this.dgv_NhaTro.DataSource = bUS_PhieuThuePhong.ListYeuCau(k.MaKH);
                this.dgv_NhaTro.Columns[4].Visible = false;
                this.dgv_NhaTro.Columns[5].Visible = false;
                dgv_NhaTro.Columns[0].HeaderText = "Mã phiếu";
                dgv_NhaTro.Columns[1].HeaderText = "Mã khách hàng";
                dgv_NhaTro.Columns[2].HeaderText = "Mã phòng";
                dgv_NhaTro.Columns[3].HeaderText = "Ngày lập";
                dgv_NhaTro.Columns[6].HeaderText = "Tình trạng";
                dgv_NhaTro.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_NhaTro.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_NhaTro.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_NhaTro.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_NhaTro.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_NhaTro.Columns[0].Width = (int)(dgv_NhaTro.Width * 0.15);
                dgv_NhaTro.Columns[1].Width = (int)(dgv_NhaTro.Width * 0.15);
                dgv_NhaTro.Columns[2].Width = (int)(dgv_NhaTro.Width * 0.15);
                dgv_NhaTro.Columns[3].Width = (int)(dgv_NhaTro.Width * 0.25);
                dgv_NhaTro.Columns[6].Width = (int)(dgv_NhaTro.Width * 0.25);
            }
            
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (this.dgv_NhaTro.CurrentRow != null)
            {
                FThongBao f = new FThongBao();
                f.TieuDe = "Xác nhận";
                f.ThongBao = "Các yêu cầu khác của phòng này sẽ bị hủy!!\nBạn muốn tiếp tục?";
                f.n = 1;
                f.ShowDialog();
                int check = 0;
                check = f.check;
                if (check != 1)
                {
                    bUS_PhieuThuePhong.duyetYeuCau(this.dgv_NhaTro.CurrentRow.Cells[0].Value.ToString());
                    FReport f1 = new FReport();
                    f1.maPhieu = this.dgv_NhaTro.CurrentRow.Cells[0].Value.ToString();
                    f1.ShowDialog();
                    this.LoadThongBaoOk("Thành công", "Xác nhận thành công", "Ok");
                    this.dgv_NhaTro.DataSource = bUS_PhieuThuePhong.ListYeuCau(k.MaKH);
                }
            }

        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void btn_huy_Click(object sender, EventArgs e)
        {
            if(this.dgv_NhaTro.CurrentRow != null)
            {
                bUS_PhieuThuePhong.huyPhieuThuePhong(this.dgv_NhaTro.CurrentRow.Cells[0].Value.ToString());
                this.LoadThongBaoOk("Thành công", "Hủy yêu cầu thành công", "Ok");
                if (check == 1)
                {
                    this.dgv_NhaTro.DataSource = bUS_PhieuThuePhong.ListPhieuThuePhongKH(k.MaKH);
                }
                else
                    this.dgv_NhaTro.DataSource = bUS_PhieuThuePhong.ListYeuCau(k.MaKH);
            }
            
        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            if(this.dgv_NhaTro.CurrentCell != null)
            {
                FThongTinKH f = new FThongTinKH();
                f.maPhieu = this.dgv_NhaTro.CurrentRow.Cells[0].Value.ToString();
                f.ShowDialog();
            }
        }
    }
}
