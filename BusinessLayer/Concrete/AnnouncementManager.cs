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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;
        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void AnnouncementAddBL(Announcement announcement)
        {
            _announcementDal.Insert(announcement);
        }

        public void AnnouncementDeleteBL(Announcement announcement)
        {
            _announcementDal.Delete(announcement);
        }
        public void AnnouncementUpdateBL(Announcement announcement)
        {
            _announcementDal.Update(announcement);   
        }

        public Announcement GetByIdBL(int id)
        {
            var value = _announcementDal.Get(x=>x.announcement_id==id);
            return value;
        }

        public List<Announcement> GetList()
        {
            return _announcementDal.List().OrderBy(x=>x.date).ToList();
        }
    }
}
