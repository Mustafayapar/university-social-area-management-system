using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEventRegisterationServise
    {
        List<EventRegisteration> GetList();
        List<EventRegisteration> GetListByID(int id);
        void EventRegisterationAddBL(EventRegisteration eventRegisteration);
        EventRegisteration GetByIdBL(int id);
        void EventRegisterationDeleteBL(EventRegisteration eventRegisteration);
        void EventRegisterationUpdateBL(EventRegisteration eventRegisteration);
    }
}
