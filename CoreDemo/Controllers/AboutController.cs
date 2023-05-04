using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class AboutController : Controller
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());
		AboutManager abm = new AboutManager(new EfAboutRepository());

		public IActionResult Index()
		{
			var about = abm.GetList();
			return View(about);
		}
		public PartialViewResult SocialMediaAbout()
		{
			var values = abm.GetList();
			return PartialView(values);
		}

		
	}
}
