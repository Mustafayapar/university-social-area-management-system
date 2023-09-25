using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommunityMessageService
    {
        List<CommunityMessage> GetListBL();
        List<CommunityMessage> GetListInBox(int id);
        List<CommunityMessage> GetListSendBox(int id);
       // int GetPresidentID(string student_number);
        void CommunityMessageAddBL(CommunityMessage communityMessage);
        CommunityMessage GetByIdBL(int id);
        void CommunityMessageDeleteBL(CommunityMessage communityMessage);
        void CommunityMessageUpdateBL(CommunityMessage communityMessage);

    }
}
