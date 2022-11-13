using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Authorization
{
    public static class AuthorizationServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization();

            //services.AddTransient<IAuthorizationPolicyProvider, CustomizedAuthorizationPolicyProvider>();
            //services.AddTransient<IAuthorizationHandler, CustomizedAuthorizationHandler>();
            //services.AddTransient<IPermissionChecker, DefaultPermissionChecker>();

            return services;
        }
    }
}
