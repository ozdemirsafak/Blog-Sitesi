using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace CoreDemo.Controllers
{

    public class WriterController : Controller
    {
        Context c = new Context();
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;
		
		public WriterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            var WriterName = c.Writers.Where(x=>x.WriterMail == usermail).Select(x => x.WriterName).FirstOrDefault();   
            ViewBag.v2 = WriterName;
            return View();
        }


        public IActionResult WriterProfile()
        {
            return View();

        }


        public IActionResult WriterMail()
        {
            return View();

        }

       
        public PartialViewResult WriterNavbarPartial()
        {
         
            return PartialView();
        }

       
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        
        [HttpGet]
        public async Task <IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.username = values.UserName;
            model.imageurl = values.ImageUrl;
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.mail;
            values.NameSurname = model.namesurname;
            values.UserName = model.username;
            values.ImageUrl = model.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");

        }
        [AllowAnonymous,HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous, HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage!=null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimaganame = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimaganame);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimaganame;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword= p.WriterPassword; 
            w.WriterStatus = p.WriterStatus;    
            w.WriterAbout = p.WriterAbout;  
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }

        

    }
}
