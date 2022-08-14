using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _LTGDIT93__01_07.BUS;

namespace _LTGDIT93__01_07
{
    public partial class UCTimTro : UserControl
    {
        BUS_Phong bUS_Phong;
        public KhachHang k;
        public UCTimTro()
        {
            InitializeComponent();
        }

        private void UCTimTro_Load(object sender, EventArgs e)
        {
            bUS_Phong = new BUS_Phong();
            this.cb_Quan.Items.AddRange(new object[] {
                "Tất cả các quận",
                "Quận 1",
                "Quận 2",
                "Quận 3",
                "Quận 4",
                "Quận 5",
                "Quận 6",
                "Quận 7",
                "Quận 8",
                "Quận 9",
                "Quận 10",
                "Quận 11",
                "Quận 12",
                "Quận Thủ Đức",
                "Quận Bình Thạnh",
                "Quận Gò Vấp",
                "Quận Phú Nhuận",
                "Quận Tân Phú",
                "Quận Bình Tân",
                "Quận Tân Bình",
                "Huyện Nhà Bè",
                "Huyện Bình Chánh",
                "Huyện Hóc Môn",
                "Huyện Củ Chi",
                "Huyện Cần Giờ"});
            this.cb_Quan.SelectedIndex = 0;
            set_dgvNhaTro();
        }

        public void set_dgvNhaTro()
        {
            dgv_NhaTro.Columns[0].HeaderText = "Mã phòng";
            dgv_NhaTro.Columns[2].HeaderText = "Diện tích";
            dgv_NhaTro.Columns[3].HeaderText = "Giá thuê";
            dgv_NhaTro.Columns[1].HeaderText = "Địa chỉ";
            dgv_NhaTro.Columns[2].DefaultCellStyle.Format = "# m2";
            dgv_NhaTro.Columns[3].DefaultCellStyle.Format = "0#,##0/tháng";
            dgv_NhaTro.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_NhaTro.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_NhaTro.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_NhaTro.Columns[0].Width = (int)(dgv_NhaTro.Width * 0.11);
            dgv_NhaTro.Columns[2].Width = (int)(dgv_NhaTro.Width * 0.13);
            dgv_NhaTro.Columns[3].Width = (int)(dgv_NhaTro.Width * 0.18);
            dgv_NhaTro.Columns[1].Width = (int)(dgv_NhaTro.Width * 0.48);

        }

        private void TrB_DienTich_Scroll(object sender, ScrollEventArgs e)
        {
            lb_DienTich.Text = TrB_DienTich.Value.ToString() + " m2";
            bUS_Phong.getListPhongBoLoc(TRb_GiaTien.Value * 200000, cb_Quan.Text, TrB_DienTich.Value, dgv_NhaTro, this.k.MaKH);
            if (dgv_NhaTro.CurrentCell != null)
            {
                pb_ToaDo.Visible = true;
                int y = dgv_NhaTro.GetCellDisplayRectangle(dgv_NhaTro.CurrentCell.ColumnIndex, dgv_NhaTro.CurrentCell.RowIndex - 1, false).Bottom + dgv_NhaTro.Top;
                this.pb_ToaDo.Location = new System.Drawing.Point(this.pb_ToaDo.Location.X, y);
            }
            else
            {
                pb_ToaDo.Visible = false;
            }
        }

        private void TRb_GiaTien_Scroll(object sender, ScrollEventArgs e)
        {
            int a = TRb_GiaTien.Value * 200000;
            lb_GiaTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", a);
            bUS_Phong.getListPhongBoLoc(TRb_GiaTien.Value * 200000, cb_Quan.Text, TrB_DienTich.Value, dgv_NhaTro, this.k.MaKH);
            if(dgv_NhaTro.CurrentCell != null)
            {
                pb_ToaDo.Visible = true;
                int y = dgv_NhaTro.GetCellDisplayRectangle(dgv_NhaTro.CurrentCell.ColumnIndex, dgv_NhaTro.CurrentCell.RowIndex - 1, false).Bottom + dgv_NhaTro.Top;
                this.pb_ToaDo.Location = new System.Drawing.Point(this.pb_ToaDo.Location.X, y);
            }
            else
            {
                pb_ToaDo.Visible = false;
            }
        }

        private void cb_Quan_SelectedIndexChanged(object sender, EventArgs e)
        {
            bUS_Phong.getListPhongBoLoc(TRb_GiaTien.Value * 200000, cb_Quan.Text, TrB_DienTich.Value, dgv_NhaTro, this.k.MaKH);
            if (dgv_NhaTro.CurrentCell != null)
            {
                pb_ToaDo.Visible = true;
                int y = dgv_NhaTro.GetCellDisplayRectangle(dgv_NhaTro.CurrentCell.ColumnIndex, dgv_NhaTro.CurrentCell.RowIndex - 1, false).Bottom + dgv_NhaTro.Top;
                this.pb_ToaDo.Location = new System.Drawing.Point(this.pb_ToaDo.Location.X, y);
            }
            else
            {
                pb_ToaDo.Visible = false;
            }
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            if(this.dgv_NhaTro.CurrentCell != null)
            {
                FChiTietPhongThue f = new FChiTietPhongThue();
                f.maPhong = this.dgv_NhaTro.CurrentRow.Cells[0].Value.ToString();
                f.k = this.k;
                f.ShowDialog();
            }
        }

        private void dgv_NhaTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.newLocationPb_ToaDo();
            }
            catch (Exception)
            {

            }
        }
        public void newLocationPb_ToaDo()
        {
            int y = 0;
            if (dgv_NhaTro.CurrentCell.RowIndex <= dgv_NhaTro.FirstDisplayedScrollingRowIndex - 1 || dgv_NhaTro.CurrentCell.RowIndex > dgv_NhaTro.FirstDisplayedScrollingRowIndex + 14)
            {
                pb_ToaDo.Visible = false;
            }
            else if (dgv_NhaTro.CurrentCell.RowIndex == dgv_NhaTro.FirstDisplayedScrollingRowIndex)
            {
                pb_ToaDo.Visible = true;
                y = dgv_NhaTro.GetCellDisplayRectangle(0, -1, false).Bottom + dgv_NhaTro.Top;
            }
            else
            {
                pb_ToaDo.Visible = true;
                y = dgv_NhaTro.GetCellDisplayRectangle(dgv_NhaTro.CurrentCell.ColumnIndex, dgv_NhaTro.CurrentCell.RowIndex - 1, false).Bottom + dgv_NhaTro.Top;
            }
            this.pb_ToaDo.Location = new System.Drawing.Point(this.pb_ToaDo.Location.X, y);
        }
        private void dgv_NhaTro_Scroll(object sender, ScrollEventArgs e)
        {
            this.newLocationPb_ToaDo();
        }
    }
}
