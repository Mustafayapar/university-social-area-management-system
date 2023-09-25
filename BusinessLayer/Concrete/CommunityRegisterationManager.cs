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
    public class CommunityRegisterationManager : ICommunityRegisterationService
    {
        ICommunityRegisterationDal _communityRegisterationDal;
        public CommunityRegisterationManager(ICommunityRegisterationDal communityRegisterationDal)
        {
            _communityRegisterationDal = communityRegisterationDal;
        }
        public void CommunityRegisterationAddBL(CommunityRegisteration communityRegisteration)
        {
            _communityRegisterationDal.Insert(communityRegisteration);
        }

        public void CommunityRegisterationDeleteBL(CommunityRegisteration communityRegisteration)
        {
            _communityRegisterationDal.Delete(communityRegisteration);
        }

        public void CommunityRegisterationUpdateBL(CommunityRegisteration communityRegisteration)
        {
            _communityRegisterationDal.Update(communityRegisteration);
        }

        public CommunityRegisteration GetByIdBL(int id)
        {
            var value = _communityRegisterationDal.Get(x=>x.id==id);
            return value;
        }

        public List<CommunityRegisteration> GetListBL()
        {
            var value = _communityRegisterationDal.List().OrderBy(x=>x.community_id).ToList();
            return value;
        }

        public List<CommunityRegisteration> GetListIdBL(int id)
        {
            var value = _communityRegisterationDal.List(x=>x.studentid==id);
            return value;
        }
    }
}
