using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICourseService
    {
        List<Course> GetList();
        void CourseAddBL(Course course);
        Course GetByIdBL(int id);
        void CourseDeleteBL(Course course);
        void CourseUpdateBL(Course course);
    }
}
