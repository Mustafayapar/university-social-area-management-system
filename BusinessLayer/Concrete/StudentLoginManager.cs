using BusinessLayer.Abstract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentLoginManager : IStudentLoginService
    {
        IStudentDal _studentDal;
        public StudentLoginManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;       
        }
        public Student GetStudent(string student_number, string password)
        {
            return _studentDal.Get(x=>x.student_number==student_number && x.password==password);
        }
    }
}
