using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LTGDIT93__01_07
{
    class DAO_KhachHang
    {
        DbQLNhaTroDataContext db;

        public DAO_KhachHang()
        {
            db = new DbQLNhaTroDataContext();
        }

        public KhachHang GetKhachHang(string userName)
        {

            return (from s in db.KhachHangs where s.UserName.Equals(userName) select s).FirstOrDefault();
        }
        public void AddKhacHang(KhachHang k, ACCOUNT ac)
        {
            db.ACCOUNTs.InsertOnSubmit(ac);
            db.SubmitChanges();
            k.MaKH = db.Max_KH();
            db.KhachHangs.InsertOnSubmit(k);
            db.SubmitChanges();
        }

    public KhachHang GetKhachHangNT(string maKH)
        {
            return db.KhachHangs.FirstOrDefault(s => s.MaKH == maKH);
        }

    }

}
