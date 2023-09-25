using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentService
    {
        List<Student> GetList();
        void StudentAddBL(Student student);
        Student GetById(int id);    
        void StudentDeleteBL(Student student);  
        void StudentUpdateBL(Student student);
    }
}
