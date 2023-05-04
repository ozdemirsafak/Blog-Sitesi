using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService:IGenericService<Blog>
	{
		//Blog GetById(int id);//bak bu methodu senin yazman gerekiyordu
		List<Blog> GetBlogListWithCategory ();

		//Yazarla Blog listesini getir.
		List<Blog> GetBlogListByWriter(int id);

		
	}
}
