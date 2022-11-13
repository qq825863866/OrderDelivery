using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Authorization
{
    public class CustomizedAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider, IAuthorizationPolicyProvider
    {
        public CustomizedAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
            : base(options)
        { }

        public new Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            var policyBuilder = new AuthorizationPolicyBuilder(Array.Empty<string>());
            policyBuilder.AddRequirements(new CustomizedAuthorizationRequirement(""));
            var policy = policyBuilder.Build();
            return Task.FromResult(policy);
        }

        public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            var policy = await base.GetPolicyAsync(policyName);
            if (policy != null)
            {
                return policy;
            }

            if (!string.IsNullOrEmpty(policyName))
            {
                var policyBuilder = new AuthorizationPolicyBuilder(Array.Empty<string>());
                policyBuilder.AddRequirements(new CustomizedAuthorizationRequirement(policyName));
                return policyBuilder.Build();
            }

            return null;
        }
    }
}
