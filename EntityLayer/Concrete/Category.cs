using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }

        public bool CategoryStatus { get; set; }

        
        //1.Adım = Blog tablosunu Category tablosuna bağladık.
        //2.Adım = Blog tablosuna gidilip işlemlere ordan devam edilir.
        public List<Blog>? Blogs { get; set; }
    }



}


