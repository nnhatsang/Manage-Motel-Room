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
    public partial class FLichSuThueTro : Form
    {
        public string maKH;
        BUS_PhieuThuePhong bUS_PhieuThuePhong;
        public FLichSuThueTro()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FLichSuThueTro_Load(object sender, EventArgs e)
        {
            bUS_PhieuThuePhong = new BUS_PhieuThuePhong();
            this.dgv_Phong.DataSource = bUS_PhieuThuePhong.LichSuThuePhong(maKH);
            this.setUpDgv();
        }

        private void setUpDgv()
        {
            dgv_Phong.Columns[0].HeaderText = "Mã phòng";
            dgv_Phong.Columns[2].HeaderText = "Ngày thuê";
            dgv_Phong.Columns[3].HeaderText = "Ngày kết thúc";
            dgv_Phong.Columns[4].HeaderText = "Tình trạng";
            dgv_Phong.Columns[1].HeaderText = "Địa chỉ";
            dgv_Phong.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Phong.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Phong.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Phong.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Phong.Columns[5].Visible = false;
            dgv_Phong.Columns[0].Width = (int)(dgv_Phong.Width * 0.09);
            dgv_Phong.Columns[2].Width = (int)(dgv_Phong.Width * 0.13);
            dgv_Phong.Columns[3].Width = (int)(dgv_Phong.Width * 0.13);
            dgv_Phong.Columns[4].Width = (int)(dgv_Phong.Width * 0.15);
            dgv_Phong.Columns[1].Width = (int)(dgv_Phong.Width * 0.40);
            for (int i = 0; i < dgv_Phong.RowCount - 1; i++)
            {
                if(dgv_Phong.Rows[i].Cells[3].Value == null)
                {
                    dgv_Phong.Rows[i].Cells[4].Value = "Đang thuê";
                }
                else
                {
                    dgv_Phong.Rows[i].Cells[4].Value = "Đã dừng thuê";
                }
                
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            if(dgv_Phong.CurrentCell == null)
            {
                return;
            }
            if(dgv_Phong.CurrentRow.Cells[4].Value.ToString() == "Đang thuê")
            {
                FThongBao f = new FThongBao();
                f.TieuDe = "Xác nhận";
                f.ThongBao = "Bạn muốn ngừng thuê trọ này?";
                f.n = 1;
                f.ShowDialog();
                int check = 0;
                check = f.check;
                if(check != 1)
                {
                    bUS_PhieuThuePhong.dungThuePhong(dgv_Phong.CurrentRow.Cells[5].Value.ToString());
                    this.dgv_Phong.DataSource = bUS_PhieuThuePhong.LichSuThuePhong(maKH);
                    this.setUpDgv();
                    f = new FThongBao();
                    f.TieuDe = "Thành công";
                    f.ThongBao = "Ngừng thuê thành công!";
                    f.YesT = "OK";
                    f.n = 0;
                    f.ShowDialog();
                }

            }  
        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            if (dgv_Phong.CurrentCell == null)
            {
                return;
            }
            FChiTietPhongThue f = new FChiTietPhongThue();
            f.check = 0;
            f.maPhong = dgv_Phong.CurrentRow.Cells[0].Value.ToString();
            f.ShowDialog();
        }
    }
}
