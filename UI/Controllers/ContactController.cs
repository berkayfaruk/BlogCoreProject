using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contact = new ContactManager(new EfContactRepository());
        private readonly INotyfService _notyf;

        public ContactController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact c)
        {
            try
            {
                c.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                c.ContactStatus = true;
                contact.ContactAdd(c);
                _notyf.Success("Yorumunuz gönderildi", 5);
                return RedirectToAction("Index", "Blog");
            }
            catch (Exception)
            {
                _notyf.Error("Yorumunuz gönderilemedi", 5);
                throw;
            }
            
        }
    }
}
