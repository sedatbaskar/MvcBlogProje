using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;

namespace MvcBlogProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager();
        public ActionResult Index()
        {
            var aboutcontent = abm.GetAll();
            return View(aboutcontent);
        }

        public PartialViewResult Footer()

        {
            var aboutcontentlist=abm.GetAll();
            
            return PartialView(aboutcontentlist);
        }

        public PartialViewResult MeetTheTeam()

        {
            AuthorManager autman = new AuthorManager();
            var authorlist = autman.GetAll();
            return PartialView(authorlist);
        }
    }
}