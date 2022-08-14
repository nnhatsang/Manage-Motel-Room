using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _LTGDIT93__01_07.DAO;

namespace _LTGDIT93__01_07.BUS
{
    class BUS_PhieuThuePhong
    {
        DAO_PhieuThuePhong dAO_PhieuThuePhong;
        public BUS_PhieuThuePhong()
        {
            dAO_PhieuThuePhong = new DAO_PhieuThuePhong();
        }
        public dynamic ListYeuCau(string maKH)
        {
            return dAO_PhieuThuePhong.ListPhieuThuePhong(maKH);
        }
        public void addPhieuThuePhong(PhieuThuePhong p)
        {
            dAO_PhieuThuePhong.addPhieuThuePhong(p);
        }
        public bool checkPhieuThue(string maKH, string maPhong)
        {
            if (dAO_PhieuThuePhong.checkPhieuThue(maKH, maPhong) == null)
                return true;
            return false;
        }
        public dynamic ListPhieuThuePhongKH(string maKH)
        {
            return dAO_PhieuThuePhong.ListPhieuThuePhongKH(maKH);
        }
        public void duyetYeuCau(string maPhieu)
        {
            dAO_PhieuThuePhong.duyetYeuCau(maPhieu);
        }

        public void huyPhieuThuePhong(string maPhieu)
        {
            this.dAO_PhieuThuePhong.huyPhieuThuePhong(maPhieu);
        }

        public dynamic LichSuThuePhong(string maKH)
        {
            return dAO_PhieuThuePhong.LichSuThuePhong(maKH);
        }

        public void dungThuePhong(string maPhieu)
        {
            dAO_PhieuThuePhong.dungThuePhong(maPhieu);
        }
        public String getMaPhieu(string maPhong)
        {
            return dAO_PhieuThuePhong.getMaPhieu(maPhong);
        }
        public PhieuThuePhong getPhieuThue(string maPhieu)
        {
            return dAO_PhieuThuePhong.getPhieuThue(maPhieu);
        }
    }
}
