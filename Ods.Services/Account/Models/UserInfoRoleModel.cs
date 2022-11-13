using AutoMapper;
using Ods.Repository.Models.System;
using Ods.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Services.Account.Models
{
    public class UserInfoRoleModel : ModelBase
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; } = "";

        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; } = "";


        public override void ConfigureMapper(Profile profile)
        {
            profile.CreateMap<SysRole, UserInfoRoleModel>();
        }
    }
}
