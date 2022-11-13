using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Ods.Common.Result;

namespace Ods.WebApi.Controllers.System
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Route("api/SysUser/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<AppResult> List()
        {
            return AppResult.Status200OK(data: "userList");
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "123")]
        public async Task<string> ListPost()
        {
            return "ListPost";
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<string> ListPost2()
        {
            return "ListPost2";
        }
    }
}
