using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICourseMessageService
    {
        List<CourseMessage> GetList();
        List<CourseMessage> GetListInBox(int id);
        List<CourseMessage> GetListSendBox(int id);
        void CourseMessageAddBL(CourseMessage courseMessage);
        CourseMessage GetById(int id);
        void CourseMessageDeleteBL(CourseMessage courseMessage);
        void CourseMessageUpdateBL(CourseMessage courseMessage);
    }
}
