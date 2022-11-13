using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Authorization
{
    public class CustomizedAuthorizationHandler : AuthorizationHandler<CustomizedAuthorizationRequirement>
    {
        private readonly IPermissionChecker _checker;

        public CustomizedAuthorizationHandler(IPermissionChecker checker)
        {
            _checker = checker;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomizedAuthorizationRequirement requirement)
        {
            if (await _checker.IsGrantedAsync(context.User, requirement.Name))
            {
                context.Succeed(requirement);
            }
        }
    }
}
