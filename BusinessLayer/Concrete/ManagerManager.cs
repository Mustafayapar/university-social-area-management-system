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
    public class ManagerManager : IManagerService
    {
        IManagerDal _managerDal;
        public ManagerManager(IManagerDal mangerDal)
        {
                _managerDal = mangerDal;
        }
        public Manager GetById(int id)
        {
            return _managerDal.Get(x=>x.manager_id==id );
        }

        public List<Manager> GetList()
        {
            return _managerDal.List().OrderBy(x=>x.manager_id).ToList();
        }

        public void ManagerAddBL(Manager manager)
        {
            _managerDal.Insert(manager);    
        }

        public void ManagerDeleteBL(Manager manager)
        {
            _managerDal.Delete(manager);
        }

        public void ManagerUpdateBL(Manager manager)
        {
            _managerDal.Update(manager);    
        }
    }
}
