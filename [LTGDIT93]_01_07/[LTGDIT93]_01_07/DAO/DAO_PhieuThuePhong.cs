using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LTGDIT93__01_07.DAO
{
    class DAO_PhieuThuePhong
    {
        DbQLNhaTroDataContext db;
        public DAO_PhieuThuePhong()
        {
            db = new DbQLNhaTroDataContext();
        }
        public void addPhieuThuePhong(PhieuThuePhong p)
        {
            p.MaPhieu = db.Max_PhieuThue();
            this.db.PhieuThuePhongs.InsertOnSubmit(p);
            this.db.SubmitChanges();
        }
        public void huyPhieuThuePhong(string maPhieu)
        {
            PhieuThuePhong p = this.db.PhieuThuePhongs.First(s => s.MaPhieu == maPhieu);
            p.TinhTrang = "Hủy";
            this.db.SubmitChanges();
        }
        public void dungThuePhong(string maPhieu)
        {
            PhieuThuePhong p = this.db.PhieuThuePhongs.First(s => s.MaPhieu == maPhieu);
            p.NgayKetThuc = DateTime.Now;
            p.TinhTrang = "Ngừng thuê";
            Phong ph = this.db.Phongs.FirstOrDefault(s => s.MaPhong == p.MaPhong);
            ph.TinhTrang = "Trống";
            this.db.SubmitChanges();
        }
        public dynamic ListPhieuThuePhong(string maKH)
        {
            return db.getListYeuCau(maKH);
        }

        public dynamic LichSuThuePhong(string maKH)
        {
            return db.pr_LichSuThueTro(maKH);
        }
        public PhieuThuePhong checkPhieuThue(string maKH, string maPhong)
        {
            return db.PhieuThuePhongs.FirstOrDefault(s => s.MaKH == maKH && s.TinhTrang == "Chờ xử lý" && s.MaPhong == maPhong);
        }
        public dynamic ListPhieuThuePhongKH(string maKH)
        {
            return db.PhieuThuePhongs.Select(s => s).Where(s => s.MaKH == maKH && s.TinhTrang == "Chờ xử lý").ToList();
        }
        public void duyetYeuCau(string maPhieu)
        {
            db.duyetYeuCau(maPhieu);
        }
        public String getMaPhieu(string maPhong)
        {
            return db.PhieuThuePhongs.FirstOrDefault(s => s.MaPhong == maPhong && s.NgayThue != null && s.NgayKetThuc == null).MaPhieu;
        }
        public PhieuThuePhong getPhieuThue(string maPhieu)
        {
            return db.PhieuThuePhongs.FirstOrDefault(s => s.MaPhieu == maPhieu);
        }
    }
}
