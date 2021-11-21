using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;

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
        [AllowAnonymous]
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

        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            cm.CategoryAddBl(p);

            return RedirectToAction("AdminCategoryList");

        }

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            Category category = cm.FindCategory(id);

            return View(category);

        }
        [HttpPost]
        public ActionResult CategoryEdit(Category p)
        {
            cm.EditCategory(p);
            return RedirectToAction("AdminCategoryList");

        }

        public ActionResult CategoryDelete(int id)
        {
            cm.CategoryStatusFalse(id);
            return RedirectToAction("AdminCategoryList");

        }
        public ActionResult CategoryStatusTrue(int id)
        {
            cm.CategoryStatusTrue(id);
            return RedirectToAction("AdminCategoryList");

        }

    }
}