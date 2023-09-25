using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDepartmentService
    {
        List<Department> GetListBL();
         void AddDepartmentBL(Department department);
        void DeleteDepartmentBL(Department department);   
        void UpdateDepartmentBL(Department department);
        Department GetByIdBL(int id); 

    }
}
