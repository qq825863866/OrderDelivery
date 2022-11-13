using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Authorization
{
    public class DefaultPermissionChecker : IPermissionChecker
    {
        public virtual Task<bool> IsGrantedAsync(ClaimsPrincipal claimsPrincipal, string name)
        {
            return Task.FromResult(true);
        }
    }
}
