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
    public class CommunityMessageManager : ICommunityMessageService
    {
        ICommunityMessageDal _communityMessageDal;
        public CommunityMessageManager(ICommunityMessageDal communityMessageDal) 
        {
            _communityMessageDal = communityMessageDal;
        }

        public void CommunityMessageAddBL(CommunityMessage communityMessage)
        {
            _communityMessageDal.Insert(communityMessage);
        }

        public void CommunityMessageDeleteBL(CommunityMessage communityMessage)
        {
           _communityMessageDal.Delete(communityMessage);
        }

        public void CommunityMessageUpdateBL(CommunityMessage communityMessage)
        {
            _communityMessageDal.Update(communityMessage);
        }

        public CommunityMessage GetByIdBL(int id)
        {
            return _communityMessageDal.Get(x=>x.message_id==id);
        }

        public List<CommunityMessage> GetListBL()
        {
            return _communityMessageDal.List().OrderBy(x=>x.message_id).ToList();
        }

        public List<CommunityMessage> GetListInBox(int id)
        {
            return _communityMessageDal.List(x => x.community_president_id == id);
        }

        public List<CommunityMessage> GetListSendBox(int id)
        {
            return _communityMessageDal.List(x => x.community_president_id == id);
        }

      
    }
}
