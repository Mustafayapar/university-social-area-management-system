using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Absract
{
    public interface IRepository<T> 
    {
        List<T> List();
        void Insert(T obj);
        T Get(Expression<Func<T, bool>> filter);
        void Delete(T obj);
        void Update(T obj);
        List<T> List(Expression<Func<T,bool>> filter );
    }
}
