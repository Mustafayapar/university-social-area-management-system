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
    public class EventManager : IEventService
    {
        IEventDal _eventDal;
        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;       
        }
        public void EventAddBL(Events obj)
        {
            _eventDal.Insert(obj);
        }

        public void EventDeleteBL(Events obj)
        {
            _eventDal.Delete(obj);  
        }

        public void EventUpdateBL(Events obj)
        {
            _eventDal.Update(obj);  
        }

        public Events GetById(int id)
        {
            return _eventDal.Get(x=>x.eid==id);
        }

        public List<Events> GetList()
        {
            return _eventDal.List();
        }

       
    }
}
