using BusinessLayer.Abstract;
using DataAccessLayer.Absract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CourseMessageManager : ICourseMessageService
    {
        ICourseMessageDal _courseMessageDal;
        public CourseMessageManager(ICourseMessageDal courseMessageDal)
        {
            _courseMessageDal = courseMessageDal;
        }
        public void CourseMessageAddBL(CourseMessage courseMessage)
        {
            _courseMessageDal.Insert(courseMessage);
        }

        public void CourseMessageDeleteBL(CourseMessage courseMessage)
        {
            _courseMessageDal.Delete(courseMessage);
        }

        public void CourseMessageUpdateBL(CourseMessage courseMessage)
        {
            _courseMessageDal.Update(courseMessage);
        }

        public CourseMessage GetById(int id)
        {
            return _courseMessageDal.Get(x => x.message_id == id);
        }

        public List<CourseMessage> GetList()
        {
            return _courseMessageDal.List().OrderBy(x=>x.date).ToList();
        }
        public List<CourseMessage> GetListInBox(int id)
        {
            return _courseMessageDal.List(x => x.president_id == id);
        }

        public List<CourseMessage> GetListSendBox(int id)
        {
            return _courseMessageDal.List(x => x.president_id == id);
        }
    }
}
