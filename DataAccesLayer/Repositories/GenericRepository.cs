using DataAccesLayer.Abstract;
using DataAccesLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T entity)
        {
            using var c = new Contexts();
            c.Add(entity);
            c.SaveChanges();
        }

        public void Delete(T entity)
        {
            using var c = new Contexts();
            c.Remove(entity);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new Contexts();
            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var c = new Contexts();

            return c.Set<T>().ToList();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var c = new Contexts();
            return c.Set<T>().Where(filter).ToList();
        }

        public void Update(T entity)
        {
            using var c = new Contexts();
            c.Update(entity);
            c.SaveChanges();
        }
    }
}
