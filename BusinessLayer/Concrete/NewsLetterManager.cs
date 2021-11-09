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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _letterDal;

        public NewsLetterManager(INewsLetterDal letterDal)
        {
            _letterDal = letterDal;
        }

        public void AddNewsLetter(NewsLetter p)
        {
            _letterDal.Add(p);
        }
    }
}
