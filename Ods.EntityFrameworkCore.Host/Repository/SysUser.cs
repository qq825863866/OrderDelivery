using System;
using System.Collections.Generic;

namespace Ods.EntityFrameworkCore.Host.Repository
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class SysUser
    {
        public SysUser()
        {
            Organizations = new HashSet<SysOrganization>();
            Roles = new HashSet<SysRole>();
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = null!;
        /// <summary>
        /// 姓名
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 性别：1-男，2-女
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// 启用状态
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// 主岗位Id
        /// </summary>
        public string? PositionId { get; set; }
        /// <summary>
        /// 主部门Id
        /// </summary>
        public string? OrganizationId { get; set; }
        /// <summary>
        /// 账号类型（1-超级管理员，2-管理员，3-普通账号）
        /// </summary>
        public int AdminType { get; set; }
        public long RowVersion { get; set; }
        /// <summary>
        /// 软删标记
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 创建用户Id
        /// </summary>
        public string? CreatedUserId { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }
        /// <summary>
        /// 更新用户Id
        /// </summary>
        public string? UpdatedUserId { get; set; }

        public virtual SysOrganization? Organization { get; set; }
        public virtual SysPosition? Position { get; set; }

        public virtual ICollection<SysOrganization> Organizations { get; set; }
        public virtual ICollection<SysRole> Roles { get; set; }
    }
}
