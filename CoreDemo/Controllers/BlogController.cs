using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    
    public class BlogController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        BlogManager bm  = new BlogManager(new EfBlogRepository());
        // IBlogService bm = null;
        // ICategoryService ct = null;


        //public BlogController()
        //  {
        //  this.bm = new BlogManager(new EfBlogRepository());
        //   this.ct = new CategoryManager(new EfCategoryRepository());

        //}
        [AllowAnonymous]
		public IActionResult BlogList()
        {
            var values = bm.GetBlogListWithCategory();  
            return View("BlogList", values);
        }
		//List sayfasından bir blog elemanına tıklanır ve buraya gelir id=55 tıklandı ve int id = 55 oldu yani benim sadece 55 id sahip olan blogağa ihtiyacım var
		[AllowAnonymous]
		public IActionResult BlogDetail(int id)
        {
            //BlogDetailViewModel model = new BlogDetailViewModel();

			ViewBag.i = id;
            var values = bm.GetBlogById(id);    
            return View(values);
        }

        //Yazar panelinde BlogListesini getirmek için
        public IActionResult BlogListByWriter() 
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();         
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd() 
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString() 
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }

		[HttpPost]
		public IActionResult BlogAdd(Blog p)
		{
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
			ValidationResult results = bv.Validate(p);
			if (results.IsValid)
			{

				p.BlogStatus = true;
				p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                bm.TAdd(p); 
				return RedirectToAction("BlogListByWriter", "Blog");

			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}

        public IActionResult DeleteBlog(int id,Blog b) 
        {
			var blogvalue = bm.TGetById(id);

			if (blogvalue.BlogStatus)
			{
				blogvalue.BlogStatus = false;
			}
			else
			{
				blogvalue.BlogStatus = true;
			}

			bm.TUpdate(blogvalue);
			return RedirectToAction("BlogListByWriter");

		}

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            // gelen idye ait blogu göster
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            p.WriterID = writerID;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");

        }
	}
}
