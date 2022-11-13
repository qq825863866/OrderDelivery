using System;
using System.Collections.Generic;

namespace Ods.EntityFrameworkCore.Host.Repository
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public partial class SysMenu
    {
        public SysMenu()
        {
            Roles = new HashSet<SysRole>();
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
        /// 应用分类
        /// </summary>
        public string? Application { get; set; }
        /// <summary>
        /// 菜单类型（0-目录，1-菜单，2-按钮）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 打开方式（0-无，1-组件，2-内链，3-外链）
        /// </summary>
        public int OpenType { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string? Icon { get; set; }
        /// <summary>
        /// 前端组件
        /// </summary>
        public string? Component { get; set; }
        /// <summary>
        /// 路由地址
        /// </summary>
        public string? Router { get; set; }
        /// <summary>
        /// 权限标识
        /// </summary>
        public string? Permission { get; set; }
        /// <summary>
        /// 是否可见（Y-是，N-否）
        /// </summary>
        public string Visible { get; set; } = null!;
        /// <summary>
        /// 内链地址
        /// </summary>
        public string? Link { get; set; }
        /// <summary>
        /// 重定向地址
        /// </summary>
        public string? Redirect { get; set; }
        /// <summary>
        /// 权重（1-系统权重，2-业务权重）
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
        /// <summary>
        /// 启用状态
        /// </summary>
        public bool IsEnabled { get; set; }
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

        public virtual ICollection<SysRole> Roles { get; set; }
    }
}
