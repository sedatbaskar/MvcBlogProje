using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcBlogProje.Controllers
{
    [AllowAnonymous]
    public class MailSubsciribeController : Controller
    {
        // GET: MailSubsciribe
        
        [HttpGet]

        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
 
        public PartialViewResult AddMail(SubscirebeMail p)
        {

            SubscirebeMailManager sm = new SubscirebeMailManager();
            sm.BLAdd(p);
            return PartialView();
        }
    }
}