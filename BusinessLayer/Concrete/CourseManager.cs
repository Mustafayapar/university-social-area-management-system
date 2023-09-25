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
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal) 
        {
            _courseDal = courseDal; 
        }

        public void CourseAddBL(Course course)
        {
            _courseDal.Insert(course);
        }

        public void CourseDeleteBL(Course course)
        {
           _courseDal.Delete(course);
        }

        public void CourseUpdateBL(Course course)
        {
            _courseDal.Update(course);
        }

        public Course GetByIdBL(int id)
        {
            return _courseDal.Get(x=>x.course_id==id);
        }

        public List<Course> GetList()
        {
            return _courseDal.List().OrderBy(x => x.course_id).ToList();
        }
    }
}
