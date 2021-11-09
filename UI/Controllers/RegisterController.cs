using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly INotyfService _notyf;
        public RegisterController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            try
            {
                WriterValidator writerValidate = new WriterValidator();
                ValidationResult results = writerValidate.Validate(p);
                if (results.IsValid)
                {
                    p.WriterStatus = true;
                    p.WriterAbout = "Deneme";
                    wm.WriterAdd(p);
                    _notyf.Success("Kayıt Başarılı", 5);
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View();
                }
               

            }
            catch (Exception)
            {
                _notyf.Error("Kayıt Başarısız Oldu", 5);
                throw;
            }
           
        }
    }
}
