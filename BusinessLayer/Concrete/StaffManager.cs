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
    public class StaffManager : IStaffService
    {
        IStaffDal _staffDal;
        public StaffManager(IStaffDal staffDal) 
        {
            _staffDal = staffDal;   
        }

        public Staff GetByIdBl(int id)
        {
            return _staffDal.Get(x=>x.staff_id==id);
        }

        public List<Staff> GetListBL()
        {
            return _staffDal.List().OrderBy(x=> x.staff_id).ToList();
        }

        public void StaffAddBL(Staff staff)
        {
            _staffDal.Insert(staff);
        }

        public void StaffDeleteBL(Staff staff)
        {
            _staffDal.Delete(staff);
        }

        public void StaffUpdateBL(Staff Staff)
        {
            _staffDal.Update(Staff);
        }
    }
}
