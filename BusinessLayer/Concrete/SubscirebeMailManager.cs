using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SubscirebeMailManager
    {
        Repository<SubscirebeMail> reposubscirebemail = new Repository<SubscirebeMail>();

        public int BLAdd(SubscirebeMail p)

        {
            if (p.Mail.Length <= 10 || p.Mail.Length >= 50)
            {
                return -1;
            }
            return reposubscirebemail.Insert(p);

        }

    }
}
