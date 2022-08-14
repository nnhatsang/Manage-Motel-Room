using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _LTGDIT93__01_07.DAO;
namespace _LTGDIT93__01_07.BUS
{
    class BUS_NhaTro
    {
        DAO_NhaTro dAO_NhaTro;
        public BUS_NhaTro()
        {
            dAO_NhaTro = new DAO_NhaTro();
        }
        public List<NhaTro> ListNhaTro(string maKH)
        {
            return dAO_NhaTro.ListNhaTro(maKH);
        }

        public int AddNhaTro(NhaTro n)
        {
           
            int KQ = 0;
            if (dAO_NhaTro.FindNhaTro(n.MaNhaTro) != null)
            {
                KQ = 0;
            }
            else
            {
                dAO_NhaTro.AddNhaTro(n);
                KQ = 1;
            }
            return KQ;
        }

        public int DeleteNhaTro(NhaTro n)
        {
            int KQ = 0;
            if (dAO_NhaTro.FindNhaTro(n.MaNhaTro) == null)
            {
                KQ = 0;
            }
            else
            {
                dAO_NhaTro.DeleteNhaTro(n);
                KQ = 1;

            }
            return KQ;
        }
        public int updateNhaTro(NhaTro n)
        {
            int KQ = 0;
            if (dAO_NhaTro.FindNhaTro(n.MaNhaTro) == null)
            {
                KQ = 0;
            }
            else
            {
                dAO_NhaTro.updateNhaTro(n);
                KQ = 1;

            }
            return KQ;
        }
        public String getDiaChi(string MaNT)
        {
            return dAO_NhaTro.getDiaChi(MaNT);
        }
        public NhaTro getNhaTro(string maNhaTro)
        {
            return dAO_NhaTro.FindNhaTro(maNhaTro);
        }
        public NhaTro findNhaTro(string maNT)
        {
            return dAO_NhaTro.FindNhaTro(maNT);
        }
    }
}


