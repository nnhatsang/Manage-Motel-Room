using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LTGDIT93__01_07.DAO
{
    class DAO_NhaTro
    {
        DbQLNhaTroDataContext db;
        public DAO_NhaTro()
        {
            db = new DbQLNhaTroDataContext();
        }
        public List<NhaTro> ListNhaTro(string maKH)
        {
            return db.NhaTros.Where(s => s.MaChuNha == maKH).ToList();
        }

        public NhaTro FindNhaTro(string MaNT)
        {
            NhaTro nhatro = db.NhaTros.FirstOrDefault(s => s.MaNhaTro == MaNT);
            return nhatro;
        }

        public void AddNhaTro(NhaTro n)
        {
            n.MaNhaTro = db.Max_NhaTro();
            db.NhaTros.InsertOnSubmit(n);
            db.SubmitChanges();
        }
        public void updateNhaTro(NhaTro n)
        {
            NhaTro nt = db.NhaTros.Single(s => s.MaNhaTro == n.MaNhaTro);
            nt.SoLuongPhong = n.SoLuongPhong;
            nt.TinhTrang = n.TinhTrang;
            nt.DiaChi = n.DiaChi;
            nt.Quan = n.Quan;
            db.SubmitChanges();
        }
        public void DeleteNhaTro(NhaTro n)
        {
            db.pr_XoaNhaTro(n.MaNhaTro);
        }
        public String getDiaChi(string MaNT)
        {
            return db.NhaTros.FirstOrDefault(s => s.MaNhaTro == MaNT).DiaChi + ", " + db.NhaTros.FirstOrDefault(s => s.MaNhaTro == MaNT).Quan;
        }
    }
}
