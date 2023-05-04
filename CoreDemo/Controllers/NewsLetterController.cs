using BusinessLayer.Concrete;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class NewsLetterController : Controller
	{
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
		AboutManager abm = new AboutManager(new EfAboutRepository());
		[HttpGet]
		public PartialViewResult NewsLetterSubscribe()
		{
			return PartialView();
		}

		[HttpPost]
		public RedirectResult NewsLetterSubscribe(NewsLetter p,Blog b)
		{
			p.MailStatus= true;
			nm.TAdd(p);
			return Redirect("/Blog/BlogDetail/"+b.BlogID);
			
		}

		//About sayfasındaki mail bülteni bölümü için
		public PartialViewResult NewsLetterForAbout()
		{
			var values = abm.GetList();
			return PartialView(values);
		}


	}
}
