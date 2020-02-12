using System;
using System.Linq;
using System.Threading.Tasks;
using EVE.ApiModels.Catalog;
using EVE.Data;

namespace EVE.Bussiness
{
    public class UserGroupBE : BaseBE<UserGroup>, IUserGroupBE
    {
        public UserGroupBE(IUnitOfWork<EVEEntities> uoW) : base(uoW)
        {
        }
        public async Task<UserGroup> GetById(UserGroupBaseReq req)
        {
            var obj = await GetAsync(c => c.UserGroupCode == req.UserGroupCode);
            if(obj != null
               && obj.Any())
            {
                return obj.FirstOrDefault();
            }

            return null;
        }

    }
}
