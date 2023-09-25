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
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal; 
        }
        public void AddDepartmentBL(Department department)
        {
            _departmentDal.Insert(department);
        }

        public void DeleteDepartmentBL(Department department)
        {
            _departmentDal.Delete(department);
        }

        public Department GetByIdBL(int id)
        {
            return _departmentDal.Get(x => x.d_id == id);
        }

        public List<Department> GetListBL()
        {
            return _departmentDal.List().OrderBy(department => department.d_id).ToList(); 
        }

        public void UpdateDepartmentBL(Department department)
        {
            _departmentDal.Update(department);
        }
    }
}
