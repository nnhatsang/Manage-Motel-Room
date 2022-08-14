using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LTGDIT93__01_07
{
    public partial class FReport : Form
    {
        public FReport()
        {
            InitializeComponent();
        }
        public string maPhieu;
        private void FReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLNhaTroDataSet.GetThongTinPhieuThue' table. You can move, or remove it, as needed.
            this.GetThongTinPhieuThueTableAdapter.Fill(this.QLNhaTroDataSet.GetThongTinPhieuThue, maPhieu);
            this.getThongTinChuNhaTableAdapter.Fill(this.qLNhaTroDataSet1.GetThongTinChuNha, maPhieu);

            this.reportViewer1.RefreshReport();
        }
    }
}
