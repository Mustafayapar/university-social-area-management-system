using DataAccessLayer.Absract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class StudentRepository :GenericRepository<Student> 
    {
        

        //public void Insert(Student obj)
        //{
            
        //}
        //public void Delete(Student obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Student obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Student> List()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Student> List(Expression<Func<Student, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        
    }
}
