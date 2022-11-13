using System;
using System.Collections.Generic;

namespace Ods.EntityFrameworkCore.Host.Repository
{
    /// <summary>
    /// 组织表
    /// </summary>
    public partial class SysOrganization
    {
        public SysOrganization()
        {
            SysUsers = new HashSet<SysUser>();
            Roles = new HashSet<SysRole>();
            Users = new HashSet<SysUser>();
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 父级Id
        /// </summary>
        public string ParentId { get; set; } = null!;
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; } = null!;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 启用状态
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
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

        public virtual ICollection<SysUser> SysUsers { get; set; }

        public virtual ICollection<SysRole> Roles { get; set; }
        public virtual ICollection<SysUser> Users { get; set; }
    }
}
