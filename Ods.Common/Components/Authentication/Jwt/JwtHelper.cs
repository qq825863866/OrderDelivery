using Microsoft.IdentityModel.Tokens;
using Ods.Common.Components.Extensions;
using Ods.Common.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Authentication.Jwt
{
    public static class JwtHelper
    {
        /// <summary>
        /// 生成 JWT Token
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        public static string Create(JwtTokenModel tokenModel)
        {
            // 获取配置
            string issuer = AppSettings.Jwt.Issuer;
            string audience = AppSettings.Jwt.Audience;
            string secret = AppSettings.Jwt.SecretKey;

            var claims = new List<Claim>()
        {
            new Claim(AuthenticationClaimTypes.UserName, tokenModel.UserName),
            new Claim(AuthenticationClaimTypes.JwtId, tokenModel.UserName),
            new Claim(AuthenticationClaimTypes.IssuedAt, DateTime.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new Claim(AuthenticationClaimTypes.NotBefore, DateTime.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new Claim(AuthenticationClaimTypes.Expiration, DateTime.Now.AddSeconds(tokenModel.Expiration).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new Claim(AuthenticationClaimTypes.Issuer, issuer),
            new Claim(AuthenticationClaimTypes.Audience, audience),
        };

            //（若令牌验证参数设置了角色RoleClaimType = AuthenticationClaimTypes.Role,）生成的token如果包含了角色，则控制器的方法的设置角色要一致才行[Authorize(Roles = "123")]，否则就不要设置角色
            foreach (var role in tokenModel.Roles)
            {
                if (string.IsNullOrEmpty(role)) continue;
                claims.Add(new Claim(AuthenticationClaimTypes.Role, role));
            }

            if (tokenModel.Claims.Count > 0)
            {
                claims.AddRange(tokenModel.Claims);
            }

            // 密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 生成 token
            var jwt = new JwtSecurityToken(claims: claims, signingCredentials: creds);
            var jwtHandler = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHandler.WriteToken(jwt);

            return encodedJwt;
        }
    }
}
