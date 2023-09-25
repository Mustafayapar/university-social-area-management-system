using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommunityService
    {
        List<Community> GetListBL();
        List<Community> GetListByID(int id);
        void CommunityAddBL(Community community);
        Community GetByIdBL(int id);
        void CommunityDeleteBL(Community community);
        void CommunityUpdateBL(Community community);
    }
}
