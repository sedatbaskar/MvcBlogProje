using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcBlogProje.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        BlogManager bm = new BlogManager();
        // GET: User
        UserProfileManager userProfile = new UserProfileManager();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];

            var profilevalues = userProfile.GetAuthorByMail(p);
            return PartialView(profilevalues);
        }


        public ActionResult UpdateUserProfile(Author p)
        {
            userProfile.EditAuthor(p);
            return RedirectToAction("Index");

        }

        public ActionResult BlogList(string p)
        {
             p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);

            return View(blogs);

        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.FindBlog(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()

                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();

            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()

                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()

                                            }).ToList();


            ViewBag.values2 = values2;
            return View(blog);

        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("AdminBlogList");

        }

        [HttpGet]
        public ActionResult AddnewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()

                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();

            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()

                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()

                                            }).ToList();


            ViewBag.values2 = values2;
            return View();

        }
        [HttpPost]
        public ActionResult AddnewBlog(Blog b)
        {
            bm.BlogAddBl(b);

            return RedirectToAction("BlogList");

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");

        }


    }
}