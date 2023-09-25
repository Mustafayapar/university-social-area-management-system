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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal) 
        {
            _userDal = userDal;
        }
        public User GetByIdBL(int id)
        {
            return _userDal.Get(x => x.id == id);
        }

        public List<User> GetList()
        {
            return _userDal.List(); 
        }

        public void UserAddBL(User user)
        {
            _userDal.Insert(user);  
        }

        public void UserDeleteBL(User user)
        {
            _userDal.Delete(user);
        }

        public void UserUpdateBL(User user)
        {
            _userDal.Update(user);  
        }
    }
}
