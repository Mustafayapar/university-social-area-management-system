using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommunityRegisterationService
    {
        List<CommunityRegisteration> GetListBL();
        List<CommunityRegisteration> GetListIdBL(int id);
        void CommunityRegisterationAddBL(CommunityRegisteration communityRegisteration);
        CommunityRegisteration GetByIdBL(int id);
        void CommunityRegisterationDeleteBL(CommunityRegisteration communityRegisteration);
        void CommunityRegisterationUpdateBL(CommunityRegisteration communityRegisteration);
    }
}
