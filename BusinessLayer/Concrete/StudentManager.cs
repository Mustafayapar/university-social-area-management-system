using BusinessLayer.Abstract;
using DataAccessLayer.Absract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal) 
        {
            _studentDal = studentDal;
        }

        public Student GetById(int id)
        {
            return _studentDal.Get(x=> x.studentid==id);
        }

        public List<Student> GetList()
        {
            return _studentDal.List().OrderBy(x => x.studentid).ToList();
        }

        public void StudentAddBL(Student student)
        {
            _studentDal.Insert(student);
        }

        public void StudentDeleteBL(Student student)
        {
            _studentDal.Update(student);
        }

        public void StudentUpdateBL(Student student)
        {
            _studentDal.Update(student);
        }
    }
}
