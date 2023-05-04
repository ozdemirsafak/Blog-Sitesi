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
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		//Writer için kategoriyle birlikte blog listeleme
		public List<Blog> GetListWithCategoryByWriterBm(int id)
		{
			return _blogDal.GetListWithCategoryByWriter(id);
		}


		// bu method var ama bunu ovverride yapmışsın
		public Blog TGetById(int id)
		{
			return _blogDal.GetByID(id);
		}

		//burada ovverride var
		public List<Blog> GetBlogById(int id)
		{
			
			return _blogDal.GetListAll(x => x.BlogID == id);
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}

		public List<Blog> GetBlogListByWriter(int id)
		{
			// WriterID ,dışarıdan gönderdiğim id ye eşit olan değerleri listele.
			return _blogDal.GetListAll(x=>x.WriterID == id);	
		}

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
			_blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
			_blogDal.Update(t);
		}

		
	}
}
