using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcBlogProje.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager cm = new CommentManager();
        public PartialViewResult CommentList(int id)
        {
            var commentList = cm.CommmentByBlog(id);
            return PartialView(commentList);
        }

        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            cm.CommentAdd(c);
            return PartialView();
        }

        public ActionResult AdminCommentListTrue()
        {
            var commentList = cm.CommentByStatusTrue();
            return View(commentList);

        }
        public ActionResult StatusChangeToFalse(int id)
        {
            cm.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue");


        }

        public ActionResult AdminCommentListFalse()
        {
            var commentList = cm.CommentByStatuesFalse();
            return View(commentList);

        }
        public ActionResult StatusChangeToTrue(int id)
        {
            cm.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListFalse");


        }
    }
}