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
using System.Data;
using System.Data.SqlClient;

namespace _LTGDIT93__01_07
{
    public partial class FXemChiTietTro : Form
    {
        public String maNhaTro;
        BUS_Phong bUS_Phong;
        BUS_NhaTro bUS_NhaTro;
        NhaTro nt;
        Phong p;
        public FXemChiTietTro()
        {
            InitializeComponent();
            cb_TinhTrang.Items.Add("Đang kinh doanh");
            cb_TinhTrang.Items.Add("Ngừng kinh doanh");
            cb_TinhTrang.SelectedIndex = 0;
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
        private void set_UpDgvPhongView()
        {
            dgv_Phong.Columns[0].HeaderText = "Mã phòng";
            dgv_Phong.Columns[2].HeaderText = "Diện tích";
            dgv_Phong.Columns[3].HeaderText = "Giá thuê";
            dgv_Phong.Columns[4].HeaderText = "Tình trạng";
            dgv_Phong.Columns[1].Visible = false;
            dgv_Phong.Columns[5].Visible = false;
            dgv_Phong.Columns[6].Visible = false;
            dgv_Phong.Columns[7].Visible = false;

            dgv_Phong.Columns[2].DefaultCellStyle.Format = "#.00, ##m2";
            dgv_Phong.Columns[3].DefaultCellStyle.Format = "0#,##0/tháng";
            dgv_Phong.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Phong.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Phong.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Phong.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv_Phong.Columns[0].Width = (int)(dgv_Phong.Width * 0.05);
            dgv_Phong.Columns[2].Width = (int)(dgv_Phong.Width * 0.05);
            dgv_Phong.Columns[3].Width = (int)(dgv_Phong.Width * 0.1);
            dgv_Phong.Columns[4].Width = (int)(dgv_Phong.Width * 0.3);

        }

        public void reset()
        {
            bUS_Phong = new BUS_Phong();
            this.dgv_Phong.DataSource = bUS_Phong.ListPhong(maNhaTro);
            this.set_UpDgvPhongView();
        }


        private void btn_Xoa_Click_1(object sender, EventArgs e)
        {
            if(this.dgv_Phong.CurrentCell != null)
            {
                Phong p = bUS_Phong.getPhong(dgv_Phong.CurrentRow.Cells[0].Value.ToString());
                if(p.TinhTrang == "Trống")
                {
                    int kq = bUS_Phong.deletePhong(p);
                    if (kq == 0)
                        this.LoadThongBaoOk("Thông báo", "Phòng này không tồn tại!", "Ok");
                    else if (kq == 1)
                        this.LoadThongBaoOk("Thông báo", "Phòng này đã được xoá thành công!", "Ok");
                    else
                        this.LoadThongBaoOk("Thông báo", "Xoá phòng không thành công!", "Ok");
                    reset();
                }
                else if(p.TinhTrang == "Đang được thuê")
                {
                    this.LoadThongBaoOk("Thông báo", "Phòng đang được thuê! Không thể xóa", "Ok");
                }
            }
        }

        private void FXemChiTietTro_Load_1(object sender, EventArgs e)
        {
            bUS_NhaTro = new BUS_NhaTro();
            bUS_Phong = new BUS_Phong();
            nt = bUS_NhaTro.getNhaTro(maNhaTro);
            this.txt_DiaChi.Text = nt.DiaChi;
            this.txt_MaNT.Text = this.maNhaTro;
            this.txt_DiaChi.Text = nt.DiaChi + ", " + nt.Quan;
            this.txt_SLPhong.Text = nt.SoLuongPhong.ToString();
            this.cb_TinhTrang.Text = nt.TinhTrang;
            reset();
        }

        private void btn_Them_Click_1(object sender, EventArgs e)
        {
            
            NhaTro nt = bUS_NhaTro.getNhaTro(maNhaTro);
            if (nt.TinhTrang == "Ngừng kinh doanh")
            {
                this.LoadThongBaoOk("Thông báo", "Trọ đã ngừng kinh doanh! Không thể thêm phòng", "Ok");
            }
            else
            {
                FThemPhong f = new FThemPhong();
                f.maNhaTro = this.maNhaTro;
                f.ShowDialog();
                reset();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if(this.dgv_Phong.CurrentCell != null)
            {
                FChiTietPhong fc = new FChiTietPhong();
                int check = 1;
                if (nt.TinhTrang == "Ngừng kinh doanh")
                    check = 0;
                fc.check = check;
                fc.maPhong = this.dgv_Phong.CurrentRow.Cells[0].Value.ToString();
                fc.ShowDialog();
                reset();
            }
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {

            NhaTro np = bUS_NhaTro.getNhaTro(maNhaTro);
            np.TinhTrang = cb_TinhTrang.Text;
            int kq = bUS_NhaTro.updateNhaTro(np);
            if (kq == 0)
                this.LoadThongBaoOk("Thông báo", "Không tồn tại nhà trọ này!", "Ok");
            else
            if (kq == 1)
            {
                this.LoadThongBaoOk("Thông báo", "Cập nhật trọ thành công!", "Ok");
            }
            else
                this.LoadThongBaoOk("Thông báo", "Cập nhật trọ không thành công!", "Ok");
            reset();
        }

        private void txt_TinhTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
