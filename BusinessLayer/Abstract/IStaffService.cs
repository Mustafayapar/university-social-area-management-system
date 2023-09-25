using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStaffService
    {
        List<Staff> GetListBL();
        void StaffAddBL(Staff staff);
        Staff GetByIdBl(int id);
        void StaffDeleteBL(Staff staff);
        void StaffUpdateBL(Staff Staff);
    }
}
