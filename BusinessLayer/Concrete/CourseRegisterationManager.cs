using BusinessLayer.Abstract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CourseRegisterationManager : ICourseRegisterationService
    {
        ICourseRegisterationDal _courseRegisterationDal;
        public CourseRegisterationManager(ICourseRegisterationDal courseRegisterationDal)
        {
            _courseRegisterationDal = courseRegisterationDal;
        }

        public void CourseRegisterationAddBL(CourseRegisteration courseRegisteration)
        {
            _courseRegisterationDal.Insert(courseRegisteration);
        }

        public void CourseRegisterationDeleteBL(CourseRegisteration courseRegisteration)
        {
           _courseRegisterationDal.Delete(courseRegisteration);
        }

        public void CourseRegisterationUpdateBL(CourseRegisteration courseRegisteration)
        {
            _courseRegisterationDal.Update(courseRegisteration);
        }

        public CourseRegisteration GetByIdBL(int id)
        {
            var value =_courseRegisterationDal.Get(x=>x.register_id==id);
            return value;
        }

        public List<CourseRegisteration> GetListBL()
        {
            return _courseRegisterationDal.List().OrderBy(x=>x.register_id).ToList();   
        }
        public List<CourseRegisteration> GetListIDBL(int id)
        {
            return _courseRegisterationDal.List(x=>x.studentid==id);
        }
    }
}
