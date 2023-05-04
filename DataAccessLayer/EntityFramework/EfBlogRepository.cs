using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
	{
		//veritabanındaki blogları ve onlarla ilişkili kategorileri çeker
		//ve bir liste olarak döndürür.
		public List<Blog> GetListWithCategory()
		{
			using(var c = new Context())
			{
				return c.Blogs.Include(x => x.Category).ToList();
			}
			
		}

		//Writer ın id sine göre kategori getirme
		public List<Blog> GetListWithCategoryByWriter(int id)
		{
			using (var c = new Context())
			{
				return c.Blogs.Include(x => x.Category).Where(x=>x.WriterID== id).ToList();
			}
		}
	}
}
