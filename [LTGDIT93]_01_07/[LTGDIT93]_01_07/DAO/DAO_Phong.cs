using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LTGDIT93__01_07.DAO
{
    class DAO_Phong
    {

        DbQLNhaTroDataContext db;
        public DAO_Phong()
        {
            db = new DbQLNhaTroDataContext();
        }
        public List<Phong> ListPhong()
        {
            return db.Phongs.Select(s => s).ToList();
        }
        public dynamic ListPhongBoLoc(int gia, string ten, int dt, string maKH)
        {
            return db.ListPhongBoLoc(gia, ten, dt, maKH);
        }
        public Phong FindPhong(string maPhong)
        {
            Phong p = db.Phongs.FirstOrDefault(s => s.MaPhong == maPhong);
            return p;
        }
        public void themPhong(Phong p)
        {
            p.MaPhong = db.Max_Phong();
            db.Phongs.InsertOnSubmit(p);
            db.SubmitChanges();
        }
        public List<Phong> ListPhong(string maNT)
        {
            return db.Phongs.Select(s => s).Where(s => s.MaNhaTro == maNT).ToList();
        }
        public void xoaPhong(Phong p)
        {
            Phong p1 = db.Phongs.FirstOrDefault(s => s.MaPhong == p.MaPhong);
            p1.TinhTrang = "Ngừng kinh doanh";
            db.SubmitChanges();
        }
        public void capNhatPhong(Phong p)
        {
            Phong np = db.Phongs.Single(s => s.MaPhong == p.MaPhong);
            np.DienTich = p.DienTich;
            np.Anh = p.Anh;
            np.TinhTrang = p.TinhTrang;
            np.GiaThue = p.GiaThue;
            np.MoTa = p.MoTa;
            db.SubmitChanges();
        }
    }
}
