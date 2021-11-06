using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            categoryDal.Add(category);
        }

        public void CategoryDelete(Category category)
        {
            categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
           return categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return categoryDal.GetListAll();
        }
    }
}
