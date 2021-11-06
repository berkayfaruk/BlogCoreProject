using DataAccesLayer.Abstract;
using DataAccesLayer.Context;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccesLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (var c=new Contexts())
            {
                return c.Blogs.Include(p => p.Category).ToList();
            }
        }
    }
}
