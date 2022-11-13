using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ods.Common.Result;
using Ods.Services.Account;
using Ods.Services.Account.Models;

namespace Ods.WebApi.Controllers
{
    /// <summary>
    /// 账号管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly ILogger<AccountController> logger;
        public AccountController(AccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            this.logger = logger;
        }

        ///// <summary>
        ///// 登录
        ///// </summary>
        ///// <param name="login"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<AppResult> Login([FromBody] LoginModel login)
        //{
        //    string token = await _accountService.GetTokenAsync(login);

        //    return AppResult.Status200OK("成功", token);
        //}

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> Login([FromBody] LoginModel login)
        {
            logger.LogInformation("AccountController Login");
            string token = await _accountService.GetTokenAsync(login);
            return token;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public string Test1([FromBody] LoginModel login)
        {
            logger.LogInformation("AccountController Test");
            throw AppResultException.Status401Unauthorized();
            //throw AppResultException.Status404NotFound("用户不存在或密码不匹配");
            int.Parse("A");
            return "Test";
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<AppResult> GetUserInfo()
        {
            var data = await _accountService.GetUserInfoAsync();
            return AppResult.Status200OK(data: data);
        }
    }
}
