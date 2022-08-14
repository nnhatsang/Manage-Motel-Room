using _LTGDIT93__01_07.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LTGDIT93__01_07.BUS
{
    class BUS_KhachHang
    {
        DAO_KhachHang dAO_KhachHang;
        DAO_ACCOUNT dAO_ACCOUNT;

        public BUS_KhachHang()
        {
            dAO_ACCOUNT = new DAO_ACCOUNT();
            dAO_KhachHang = new DAO_KhachHang();
        }
        public KhachHang GetKhachHang(string userName)
        {
            KhachHang k = dAO_KhachHang.GetKhachHang(userName);
            return k;
        }

        public int AddKhachHang(KhachHang t, ACCOUNT pass)
        {
            int kq;
            if (dAO_ACCOUNT.checkAccountExists(t.UserName) != null)
            {
                kq = 0;
            }
            else
            {
                dAO_KhachHang.AddKhacHang(t, pass);
                kq = 1;
            }
            return kq;

        }


        public KhachHang GetKhachHangNT(string maKH)
        {
            return dAO_KhachHang.GetKhachHangNT(maKH);
        }
    }
}
