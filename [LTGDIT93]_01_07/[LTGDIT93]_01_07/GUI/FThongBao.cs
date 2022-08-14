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
    public partial class FThongBao : Form
    {
        public string TieuDe, ThongBao, YesT = "Yes", NoT = "No";
        public int y, n;
        public int check;

        private void btn_No_Click(object sender, EventArgs e)
        {
            check = 1;
            this.Close();
        }

        private void btn_Yes_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        public FThongBao()
        {
            InitializeComponent();
        }

        private void FThongBao_Load(object sender, EventArgs e)
        {
            lbl_ThongBao.Text = ThongBao;
            lb_Title.Text = TieuDe;

            btn_No.Text = NoT;
            btn_Yes.Text = YesT;
            if (n == 1)
                btn_No.Visible = true;
        }
    }
}
