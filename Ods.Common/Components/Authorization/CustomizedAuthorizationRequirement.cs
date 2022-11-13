using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Authorization
{
    public class CustomizedAuthorizationRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }

        public CustomizedAuthorizationRequirement(string name)
        {
            Name = name;
        }
    }
}
