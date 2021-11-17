using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcBlogProje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ContactManager cm = new ContactManager();
        [AllowAnonymous]
        public ActionResult Index()
        {


            return View();
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddContact(Contact p)
        {
            cm.BLContactAdd(p);
            return View();

        }

        public ActionResult SendBox()
        {

            var messagelist = cm.GetAll();
            return View(messagelist);

        }
        public ActionResult MessageDetails(int id)
        {

            Contact contact = cm.GetContactDetails(id);
            return View(contact);

        }

    }
}