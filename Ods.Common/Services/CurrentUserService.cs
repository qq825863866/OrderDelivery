using Ods.Common.Components.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Services
{
    public interface ICurrentUserService
    {
        ClaimsPrincipal User { get; }
        bool IsAuthenticated { get; }
        Guid? UserId { get; }
        string? UserName { get; }
        string[] Roles { get; }
        string? Name { get; }
        string? Email { get; }
        Guid? TenantId { get; }
        bool IsSuperAdmin { get; }

        bool IsInRole(string roleName);
        Claim? FindClaim(string claimType);
        Claim[] FindClaims(string claimType);
        string? FindClaimValue(string claimType);
    }

    public class CurrentUserService : ICurrentUserService
    {
        protected readonly IBaseService _baseService;

        public CurrentUserService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public virtual ClaimsPrincipal User
        {
            get
            {
                // 如果 Identity 为 null 则抛出异常
                if (_baseService.HttpContext.User.Identity == null)
                {
                    throw new Exception("不能获取到当前用户的状态！");
                }
                return _baseService.HttpContext.User;
            }
        }

        public virtual bool IsAuthenticated => User.Identity!.IsAuthenticated;

        public virtual string? UserName => FindClaimValue(AuthenticationClaimTypes.UserName); // User.Identity!.Name;

        public virtual string[] Roles => FindClaims(AuthenticationClaimTypes.Role).Select(c => c.Value).ToArray();

        public virtual string? Name => FindClaimValue(AuthenticationClaimTypes.Name);

        public virtual string? Email => FindClaimValue(AuthenticationClaimTypes.Email);

        public virtual Guid? UserId
        {
            get
            {
                if (Guid.TryParse(FindClaimValue(AuthenticationClaimTypes.UserId), out Guid result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public virtual Guid? TenantId
        {
            get
            {
                if (Guid.TryParse(FindClaimValue(AuthenticationClaimTypes.Tenant), out Guid result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public virtual bool IsSuperAdmin => FindClaimValue(AuthenticationClaimTypes.AdminType) == "SuperAdmin";

        public virtual bool IsInRole(string roleName)
        {
            return FindClaims(AuthenticationClaimTypes.Role).Any(c => c.Value == roleName);
        }

        public virtual Claim? FindClaim(string claimType)
        {
            return User.Claims.FirstOrDefault(c => c.Type == claimType);
        }

        public virtual Claim[] FindClaims(string claimType)
        {
            return User.Claims.Where(c => c.Type == claimType).ToArray();
        }

        public virtual string? FindClaimValue(string claimType)
        {
            return FindClaim(claimType)?.Value;
        }
    }
}
