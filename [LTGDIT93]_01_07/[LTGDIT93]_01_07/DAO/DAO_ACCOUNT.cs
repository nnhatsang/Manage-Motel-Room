using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _LTGDIT93__01_07.DAO
{

    class DAO_ACCOUNT
    {
        DbQLNhaTroDataContext db;

        public DAO_ACCOUNT()
        {
            db = new DbQLNhaTroDataContext();
        }
        public ACCOUNT GetACCOUNT(ACCOUNT a1)
        {
            ACCOUNT a = db.ACCOUNTs.FirstOrDefault(s => s.UserName == a1.UserName && s.PassWord == a1.PassWord);
            return a;
        }
        public ACCOUNT checkAccountExists(string us)
        {
            return db.ACCOUNTs.FirstOrDefault(s => s.UserName == us);
        }
        public void updatePass(ACCOUNT a)
        {
            ACCOUNT acc = db.ACCOUNTs.FirstOrDefault(s => s.UserName == a.UserName);
            acc.PassWord = a.PassWord;
            db.SubmitChanges();
        }


    }
}
