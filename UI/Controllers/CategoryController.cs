using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        //burada ICategory interfacesi sayesinde istediğimiz orm yi ekleme şansı elde ediyoruz.Mesala daha sonra Nhibernate yi ekleyebilirim.
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = categoryManager.GetList();
            return View(values);
        }
    }
}
