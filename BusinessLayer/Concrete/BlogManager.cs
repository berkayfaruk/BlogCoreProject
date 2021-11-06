using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogServive
    {
        IBlogDal blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            this.blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            blogDal.Delete(blog);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return blogDal.GetListWithCategory();
        }

        public Blog GetById(int id)
        {
            return blogDal.GetById(id);
        }

        public List<Blog> GetList()
        {
            return blogDal.GetListAll();
        }

        public void Update(Blog blog)
        {
            blogDal.Update(blog);
        }
    }
}
