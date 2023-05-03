using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    // Default kısmını kullanıcı giriş yapmadan görebilmeli o yüzden o kısmı ekledik.

    [AllowAnonymous]   // Bunun altında bulunan metotları projenin genelinde uygulanan kurallardan muaf tut demek.
    public class DefaultController : Controller
    {
        private readonly IContactService _contactService;

		public DefaultController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IActionResult Index()
        {
            
            return View();
        }

        // Mesaj gönderme işlemi için

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

		[HttpPost]
		public IActionResult SendMessage(Contact contact)
		{
            //Tarih 
            contact.Date=DateTime.Parse(DateTime.Now.ToShortDateString());  
            // Ekleme işlemi
            _contactService.Insert(contact);

			return RedirectToAction("Index","Default");
		}

        // Script kısımları için partial tanımlıyoruz
        public PartialViewResult ScriptPartial()  // Addview diyoruz.
        {
            return PartialView();
        }


	}
}
