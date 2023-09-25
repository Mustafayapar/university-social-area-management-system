using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICourseRegisterationService
    {
        List<CourseRegisteration> GetListBL();
        List<CourseRegisteration> GetListIDBL(int id);
        void CourseRegisterationAddBL(CourseRegisteration courseRegisteration);
        CourseRegisteration GetByIdBL(int id);
        void CourseRegisterationDeleteBL(CourseRegisteration courseRegisteration);
        void CourseRegisterationUpdateBL(CourseRegisteration courseRegisteration);
    }
}
