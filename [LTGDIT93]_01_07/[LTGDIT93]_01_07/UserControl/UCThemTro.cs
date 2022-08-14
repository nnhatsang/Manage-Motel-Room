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
    public partial class UCThemTro : UserControl
    {
        public NhaTro nt;
        public KhachHang k;
        BUS_NhaTro bUS_NhaTro;
        public string MaNhaTro;
        public UCThemTro()
        {
            InitializeComponent();
        }

        public void set_dgvNhaTro()
        {
            dgv_NhaTro.Columns[0].HeaderText = "Mã nhà trọ";
            dgv_NhaTro.Columns[1].Visible = false;
            dgv_NhaTro.Columns[2].HeaderText = "Địa chỉ";
            dgv_NhaTro.Columns[3].HeaderText = "Số lượng phòng";
            dgv_NhaTro.Columns[4].HeaderText = "Tình trạng";
            dgv_NhaTro.Columns[5].Visible = false;
            dgv_NhaTro.Columns[6].Visible = false;


            dgv_NhaTro.Columns[0].Width = (int)(dgv_NhaTro.Width * 0.07);
            dgv_NhaTro.Columns[2].Width = (int)(dgv_NhaTro.Width * 0.3);
            dgv_NhaTro.Columns[3].Width = (int)(dgv_NhaTro.Width * 0.08);
            dgv_NhaTro.Columns[4].Width = (int)(dgv_NhaTro.Width * 0.3);
            for (int i = 0; i <= dgv_NhaTro.RowCount - 1; i++)
            {
                dgv_NhaTro.Rows[i].Cells[2].Value = dgv_NhaTro.Rows[i].Cells[2].Value + ", " + dgv_NhaTro.Rows[i].Cells[5].Value;
            }
        }

        public void reset()
        {
            bUS_NhaTro = new BUS_NhaTro();
            dgv_NhaTro.DataSource = bUS_NhaTro.ListNhaTro(this.k.MaKH);
            this.set_dgvNhaTro();
        }


        private void btn_XoaTro_Click_1(object sender, EventArgs e)
        {
            if(dgv_NhaTro.CurrentCell != null)
            {
                NhaTro n = new NhaTro();
                n.MaNhaTro = dgv_NhaTro.CurrentRow.Cells[0].Value.ToString();
                int KQ = bUS_NhaTro.DeleteNhaTro(n);
                if (KQ == 0)
                {
                    MessageBox.Show("Nhà trọ này chưa tồn tại!");
                }
                else if (KQ == 1)
                {
                    MessageBox.Show("Xoá thành công!");
                    bUS_NhaTro = new BUS_NhaTro();
                }
                else if (KQ != 1)
                {
                    MessageBox.Show("Xoá không thành công!");
                }

                reset();
            }
            
        }



        private void UCThemTro_Load_1(object sender, EventArgs e)
        {
            bUS_NhaTro = new BUS_NhaTro();

            dgv_NhaTro.DataSource = bUS_NhaTro.ListNhaTro(k.MaKH);
            set_dgvNhaTro();
        }

        private void btn_XemChiTiet_Click(object sender, EventArgs e)
        {
            if(dgv_NhaTro.CurrentCell != null)
            {
                FXemChiTietTro f = new FXemChiTietTro();
                f.maNhaTro = (string)this.dgv_NhaTro.CurrentRow.Cells[0].Value;
                this.Parent.Parent.Hide();
                f.ShowDialog();
                this.Parent.Parent.Show();
                reset();
            }
            
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            FThemTro f = new FThemTro();
            f.k = this.k;
            f.ShowDialog();
            reset();
        }

        private void btn_DSYeuCau_Click(object sender, EventArgs e)
        {
            FYeuCauThuePhong f = new FYeuCauThuePhong();
            f.k = this.k;
            this.Parent.Parent.Hide();
            f.ShowDialog();
            this.Parent.Parent.Show();
        }
    }
}

