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
    public class EventRegisterationManager : IEventRegisterationServise
    {
        IEventRegisterationDal _eventRegisterationDal;

        public EventRegisterationManager(IEventRegisterationDal eventRegisterationDal) 
        {
            _eventRegisterationDal = eventRegisterationDal;
        }
        public void EventRegisterationAddBL(EventRegisteration eventRegisteration)
        {
            _eventRegisterationDal.Insert(eventRegisteration);
        }

        public void EventRegisterationDeleteBL(EventRegisteration eventRegisteration)
        {
            _eventRegisterationDal.Delete(eventRegisteration); 
        }

        public void EventRegisterationUpdateBL(EventRegisteration eventRegisteration)
        {
            _eventRegisterationDal.Update(eventRegisteration); 
        }

        public EventRegisteration GetByIdBL(int id)
        {
            return _eventRegisterationDal.Get(x => x.id == id);
        }

        public List<EventRegisteration> GetList()
        {
            return _eventRegisterationDal.List().OrderBy(x => x.id).ToList();
        }

        public List<EventRegisteration> GetListByID(int id)
        {
            return _eventRegisterationDal.List(x => x.studentid == id);
        }
    }
}
