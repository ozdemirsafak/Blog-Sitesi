using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.NewsLetter
{
	public class NewsLetterSubscribe : ViewComponent
	{
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
		public IViewComponentResult Invoke(int id)
		{
			//var values = nm.GetList(id);
			return View();

		}



	}


}
