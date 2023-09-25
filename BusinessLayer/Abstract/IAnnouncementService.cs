using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAnnouncementService
    {
        List<Announcement> GetList();
        void AnnouncementAddBL(Announcement announcement);
        Announcement GetByIdBL(int id);
        void AnnouncementDeleteBL(Announcement announcement);
        void AnnouncementUpdateBL(Announcement announcement);
    }
}
