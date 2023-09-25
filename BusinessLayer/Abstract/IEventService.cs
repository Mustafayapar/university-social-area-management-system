using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEventService
    {
        List<Events> GetList();
       
        void EventAddBL(Events obj);
        Events GetById(int id);
        void EventDeleteBL(Events obj);
        void EventUpdateBL(Events obj);
    }
}
