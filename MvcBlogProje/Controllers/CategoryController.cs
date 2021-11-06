using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;

namespace MvcBlogProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager();

        public ActionResult Index()
        {
            var categoryvalues = cm.GetAll();
            return View (categoryvalues);



        }

        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryvalues = cm.GetAll();
            return PartialView(categoryvalues);

            
        }

        public ActionResult AdminCategoryList()
        {
            var categorylist = cm.GetAll();
            return View(categorylist);

        }
    }
}