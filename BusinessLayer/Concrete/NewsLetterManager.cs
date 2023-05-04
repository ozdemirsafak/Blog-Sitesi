using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class NewsLetterManager:INewsLetterService
	{
		INewsLetterDal _newsletterDal;

		public NewsLetterManager(INewsLetterDal newsletterDal)
		{
			_newsletterDal = newsletterDal;
		}

        public NewsLetter TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> GetList(int id)
		{
			return _newsletterDal.GetListAll(x => x.MailID == id);
		}

        public List<NewsLetter> GetList()
        {
            throw new NotImplementedException();
        }



        public void TAdd(NewsLetter t)
        {
            _newsletterDal.Insert(t);
        }

        public void TDelete(NewsLetter t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(NewsLetter t)
        {
            throw new NotImplementedException();
        }

		
	}
}
