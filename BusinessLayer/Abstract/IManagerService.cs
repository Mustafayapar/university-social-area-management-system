using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IManagerService
    {
        List<Manager> GetList();
        void ManagerAddBL(Manager manager);
        Manager GetById(int id);
        void ManagerDeleteBL(Manager manager);
        void ManagerUpdateBL(Manager manager);
    }
}
