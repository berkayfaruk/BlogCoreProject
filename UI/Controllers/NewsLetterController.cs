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
    public class NewsLetterController : Controller
    {
        NewsLetterManager letterManager = new NewsLetterManager(new EfNewsLetterRepository());

        private readonly INotyfService _notyf;
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter p)
        {
            try
            {
                p.MailStatus = true;
                letterManager.AddNewsLetter(p);
                _notyf.Success("Mail gönderildi.", 5);
                return PartialView();
            }
            catch (Exception)
            {
                _notyf.Error("Mail gönderilemedi.", 5);
                throw;
            }
            
        }
    }
}
