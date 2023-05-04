using BusinessLayer.Concrete;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView("BlogList");	
		}
		[HttpPost]
		public RedirectResult PartialAddComment(Comment p)
		{
			p.BlogID= p.BlogID;
			p.CommentDate= DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
			cm.CommentAdd(p);
			return Redirect("/Blog/BlogDetail/"+p.BlogID);
		}

		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView(values);
		}
	}
}





