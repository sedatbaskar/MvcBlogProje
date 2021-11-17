using System;
using System.Collections.Generic;
using System.Linq;
using PagedList.Mvc;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using PagedList;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using System.Windows;

namespace MvcBlogProje.Controllers
{
   
    public class BlogController : Controller
    {
        // GET: Blog

        
        BlogManager bm = new BlogManager();


        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult BlogList(int page = 1)
        {
            var bloglist = bm.GetAll().ToPagedList(page, 6);
            return PartialView(bloglist);

        }

        public PartialViewResult FeaturesPosts()
        {
            //1.Post
            var posttitle1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();

            var postImage1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();


            var Blogdate1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var Blogpostid = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.Blogdate1 = Blogdate1;
            ViewBag.Blogpostid = Blogpostid;

            //2.Post
            var posttitle2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();

            var postImage2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();


            var Blogdate2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var Blogpostid2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle2 = posttitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.Blogdate2 = Blogdate2;
            ViewBag.Blogpostid2 = Blogpostid2;
            //3.Post

            var posttitle3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();

            var postImage3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();


            var Blogdate3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var Blogpostid3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle3 = posttitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.Blogdate3 = Blogdate3;
            ViewBag.Blogpostid3 = Blogpostid3;


            //4.Post

            var posttitle4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();

            var postImage4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();


            var Blogdate4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            var Blogpostid4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle4 = posttitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.Blogdate4 = Blogdate4;
            ViewBag.Blogpostid4 = Blogpostid4;



            //5.Post

            var posttitle5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogTitle).FirstOrDefault();

            var postImage5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogImage).FirstOrDefault();


            var Blogdate5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogDate).FirstOrDefault();
            var Blogpostid5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle5 = posttitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.Blogdate5 = Blogdate5;
            ViewBag.Blogpostid5 = Blogpostid5;


            return PartialView();
        }
        public PartialViewResult OthersFeaturesPosts()
        {




            return PartialView();

        }

        [AllowAnonymous]
        public ActionResult BlogDetalis()
        {


            return View();

        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var blogDetailsList = bm.GetBlogByID(id);
            return PartialView(blogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {

            var blogDetailsList = bm.GetBlogByID(id);

            return PartialView(blogDetailsList);

        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            var CategoryDes = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDes = CategoryDes;
            return View(BlogListByCategory);

        }

      
        public ActionResult AdminBlogList()
        {


            var bloglist = bm.GetAll();
            return View(bloglist);

        }



        public ActionResult AdminBlogList2()
        {


            var bloglist = bm.GetAll();
            return View(bloglist);

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

            return RedirectToAction("AdminBlogList");

        }

        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList");


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
            return RedirectToAction("BlogList");
           

        }
        public ActionResult GetCommmentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentList = cm.CommmentByBlog(id);
            return View(commentList);



        }
    }
}