using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Authorization
{
    public interface IPermissionChecker
    {
        Task<bool> IsGrantedAsync(ClaimsPrincipal claimsPrincipal, string name);
    }

}
