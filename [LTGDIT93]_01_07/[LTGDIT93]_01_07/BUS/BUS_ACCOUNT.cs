using _LTGDIT93__01_07.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LTGDIT93__01_07.BUS
{
    class BUS_ACCOUNT
    {
        DAO_ACCOUNT dAO_ACCOUNT;

        public BUS_ACCOUNT()
        {
            dAO_ACCOUNT = new DAO_ACCOUNT();
        }

        public int checkACCOUNT(ACCOUNT a)
        {
            int kq = 0;
            if (dAO_ACCOUNT.GetACCOUNT(a) != null)
            {
                kq = 1;
            }
            else
            {
                kq = -1;
            }
            return kq;
        }

        public int updatePass(ACCOUNT a)
        {
            int kq = 0;
            if (a.UserName == null)
            {
                kq = 0;
            }
            else
            {
                try
                {
                    dAO_ACCOUNT.updatePass(a);
                    kq = 1;
                }
                catch (Exception e)
                {
                    kq = -1;
                }
            }
            return kq;
        }
        public ACCOUNT GetACCOUNT(string us)
        {
            return dAO_ACCOUNT.checkAccountExists(us);
        }
    }
}
