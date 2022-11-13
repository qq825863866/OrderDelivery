using Microsoft.EntityFrameworkCore;
using Ods.Common.Components.Authentication;
using Ods.Common.Components.Authentication.Jwt;
using Ods.Common.Components.Mapper;
using Ods.Common.Helpers;
using Ods.Common.Result;
using Ods.Common.Services;
using Ods.Repository.Data;
using Ods.Repository.Models.System;
using Ods.Services.Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Services.Account
{
    public class AccountService
    {
        private readonly OdsDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public AccountService(ICurrentUserService currentUser, OdsDbContext context)
        {
            _currentUser = currentUser;
            _context = context;
        }

        /// <summary>
        /// 获取 JwtToken
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<string> GetTokenAsync(LoginModel login)
        {
            var passwordHash = HashHelper.Md5(login.Password);

            //var user = await _context.Set<SysUser>()
            //    .Include(u => u.UserRoles)
            //    .Where(u => u.UserName == login.Account)
            //    .Where(u => u.Password == passwordHash)
            //    .FirstOrDefaultAsync();

            //if (user == null)
            //{
            //    throw AppResultException.Status404NotFound("用户不存在或密码不匹配");
            //}

            //if (!user.IsEnabled)
            //{
            //    throw AppResultException.Status403Forbidden("该账号已被停用");
            //}

            // 用户信息
            List<Claim> claims = new List<Claim>()
        {
                //new Claim(AuthenticationClaimTypes.UserId, user.Id.ToString()),
                //new Claim(AuthenticationClaimTypes.Name, user.Name ?? ""),
                //new Claim(AuthenticationClaimTypes.Email, user.Email?? ""),
                //new Claim(AuthenticationClaimTypes.AdminType, user.AdminType.ToString()),
                new Claim(AuthenticationClaimTypes.UserId, "123"),
                new Claim(AuthenticationClaimTypes.Name, "czq"),
                new Claim(AuthenticationClaimTypes.Email,"czq@qq.com"),
                new Claim(AuthenticationClaimTypes.AdminType, "管理员"),
            };
            string[] roles = new string[] { "123", "456" };//user.UserRoles.Select(ur => ur.RoleId.ToString()).ToArray();

            // 生成 token
            var jwtTokenModel = new JwtTokenModel(login.Account, claims, roles);
            string token = JwtHelper.Create(jwtTokenModel);

            return token;
        }

        /// <summary>
        /// 获取用户信息（适配小诺1.8 vue前端）
        /// </summary>
        /// <returns></returns>
        public async Task<UserInfoModel> GetUserInfoAsync()
        {
            if (_currentUser.UserId == null)
            {
                throw AppResultException.Status401Unauthorized();
            }

            var result = new UserInfoModel();

            // 关联 UserRole 查询用户
            var user = await _context.Set<SysUser>()
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Include(u => u.UserDataScopes)
                .Where(u => u.Id == _currentUser.UserId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw AppResultException.Status404NotFound("???");
            }

            // SysUser 映射为 UserInfoModel
            MapperHelper.Map(user, result);

            // 角色Id 列表
            var roleIds = user.UserRoles.Select(ur => ur.RoleId);

            // Roles 角色信息
            List<SysRole> roles = user.UserRoles.Where(ur => ur.Role != null).Select(ur => ur.Role!).ToList();
            result.Roles = MapperHelper.Map<List<UserInfoRoleModel>>(roles);

            //// Apps 应用信息
            //result.Apps = await GetUserApplicationsAsync(user);
            //// 如果没有默认应用，设定第一个为默认应用
            //if (result.Apps.Count > 0 && !(result.Apps.Any(a => a.Active)))
            //{
            //    result.Apps[0].Active = true;
            //}

            //// Menus 菜单信息
            //result.Menus = await GetUserMenusAsync(user);

            //// Permissions 权限信息
            //result.Permissions = await GetUserPermissionsAsync(user);

            return result;
        }
    }
}
