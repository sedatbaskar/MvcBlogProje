using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcBlogProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            Context c = new Context();

            var userinfo = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if (userinfo != null)
            {

                FormsAuthentication.SetAuthCookie(userinfo.Mail, false);
                Session["Mail"] = userinfo.Mail.ToString();
                return RedirectToAction("BlogList", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            Context c = new Context();

            var admininfo = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (admininfo != null)
            {

                FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
                Session["UserName"] = admininfo.UserName.ToString();
                return RedirectToAction("AdminBlogList2", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }

    }
}