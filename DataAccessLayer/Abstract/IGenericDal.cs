using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    // Dışarıdan bir T parametresi alıcak.Ve T değeri bir class'a ait tüm değerleri kullancak.
    // Teker Teker CategoryDal ve BlogDal gibi oluşturmadık.Tüm classlar tek bir interface
    // ile işlemlerine devam edecek.
    public interface IGenericDal<T> where T:class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetListAll();

        //ID parametresini almak için,T türünde.
        T GetByID(int id);

        List<T> GetListAll(Expression<Func<T, bool>> filter);
          
        
    }
}
