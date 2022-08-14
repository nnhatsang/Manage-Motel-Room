using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using _LTGDIT93__01_07.DAO;

namespace _LTGDIT93__01_07.BUS
{

    class BUS_Phong
    {
        DAO_Phong dAO_Phong;
        public BUS_Phong()
        {
            dAO_Phong = new DAO_Phong();
        }
        public List<Phong> ListPhong(string maNT)
        {
            return dAO_Phong.ListPhong(maNT);
        }
        public int AddPhong(Phong p)
        {

            int kq = 0;
            if (dAO_Phong.FindPhong(p.MaPhong) != null)
            {
                kq = 0;
            }
            else
            {
                try
                {
                    dAO_Phong.themPhong(p);
                    kq = 1;
                }
                catch (Exception ex)
                {
                    kq = -1;
                }
            }
            return kq;
        }
        public int deletePhong(Phong p)
        {
            int kq = 0;
            if (dAO_Phong.FindPhong(p.MaPhong) == null)
            {
                kq = 0;
            }
            else
            {
                try
                {
                    dAO_Phong.xoaPhong(p);
                    kq = 1;
                }
                catch (Exception ex)
                {
                    kq = -1;
                }
            }
            return kq;
        }
        public int updatePhong(Phong p)
        {
            int kq = 0;
            if (dAO_Phong.FindPhong(p.MaPhong) == null)
            {
                kq = 0;
            }
            else
            {
                try
                {
                    dAO_Phong.capNhatPhong(p);
                    kq = 1;
                }
                catch (Exception ex)
                {
                    kq = -1;
                }
            }
            return kq;
        }
        //public string getImg(string maPhong)
        //{
        //    return dAO_Phong.FindPhong(maPhong).Anh;
        //}
        public Phong getPhong(string maPhong)
        {
            return dAO_Phong.FindPhong(maPhong);
        }
       
        public void getListPhongBoLoc(int gia, string ten, int dt, DataGridView dg, string maKH)
        {
            if(ten == "Tất cả các quận")
            {
                dg.DataSource = dAO_Phong.ListPhongBoLoc(gia, null, dt, maKH);
            }
            else
            {
                dg.DataSource = dAO_Phong.ListPhongBoLoc(gia, ten, dt, maKH);
            }
        }
       
    }
}
