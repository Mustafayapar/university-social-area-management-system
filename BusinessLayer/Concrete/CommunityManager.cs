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
    public class CommunityManager : ICommunityService
    {
        ICommunityDal _communityDal;
        public CommunityManager(ICommunityDal communityDal)
        {
            _communityDal = communityDal;   
        }
        public void CommunityAddBL(Community community)
        {
            _communityDal.Insert(community);
        }

        public void CommunityDeleteBL(Community community)
        {
            _communityDal.Delete(community);
        }

        public void CommunityUpdateBL(Community community)
        {
            _communityDal.Update(community);
        }

        public Community GetByIdBL(int id)
        {
            var value =_communityDal.Get(x => x.community_id == id);
            return value;
        }

        public List<Community> GetListBL()
        {
            var value = _communityDal.List().OrderBy(x=>x.community_id).ToList();
            return value;   
        }

        public List<Community> GetListByID(int id)
        {
            return _communityDal.List(x => x.community_president_id == id);
        }

        
    }
}
