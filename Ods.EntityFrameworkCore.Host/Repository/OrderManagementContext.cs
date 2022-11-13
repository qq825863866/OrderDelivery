//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace Ods.EntityFrameworkCore.Host.Repository
//{
//    public partial class OrderManagementContext : DbContext
//    {
//        public OrderManagementContext()
//        {
//        }

//        public OrderManagementContext(DbContextOptions<OrderManagementContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<SysApplication> SysApplications { get; set; } = null!;
//        public virtual DbSet<SysMenu> SysMenus { get; set; } = null!;
//        public virtual DbSet<SysOrganization> SysOrganizations { get; set; } = null!;
//        public virtual DbSet<SysPosition> SysPositions { get; set; } = null!;
//        public virtual DbSet<SysRole> SysRoles { get; set; } = null!;
//        public virtual DbSet<SysUser> SysUsers { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OrderManagement;Persist Security Info=True;User ID=sa;Password=.NETczq19920601;Connect Timeout=500;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<SysApplication>(entity =>
//            {
//                entity.ToTable("SysApplication");

//                entity.HasComment("应用表");

//                entity.Property(e => e.Id)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("主键");

//                entity.Property(e => e.Code)
//                    .HasMaxLength(128)
//                    .HasComment("编码");

//                entity.Property(e => e.CreatedTime).HasComment("创建时间");

//                entity.Property(e => e.CreatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("创建用户Id");

//                entity.Property(e => e.IsActive).HasComment("是否激活（只能同时激活一个应用）。");

//                entity.Property(e => e.IsDeleted)
//                    .IsRequired()
//                    .HasDefaultValueSql("(CONVERT([bit],(0)))")
//                    .HasComment("软删标记");

//                entity.Property(e => e.IsEnabled).HasComment("启用状态");

//                entity.Property(e => e.Name)
//                    .HasMaxLength(128)
//                    .HasComment("名称");

//                entity.Property(e => e.Remark)
//                    .HasMaxLength(2048)
//                    .HasComment("备注");

//                entity.Property(e => e.Sort).HasComment("排序");

//                entity.Property(e => e.UpdatedTime).HasComment("更新时间");

//                entity.Property(e => e.UpdatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("更新用户Id");
//            });

//            modelBuilder.Entity<SysMenu>(entity =>
//            {
//                entity.ToTable("SysMenu");

//                entity.HasComment("菜单表");

//                entity.Property(e => e.Id)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("主键");

//                entity.Property(e => e.Application)
//                    .HasMaxLength(128)
//                    .HasComment("应用分类");

//                entity.Property(e => e.Code)
//                    .HasMaxLength(128)
//                    .HasComment("编码");

//                entity.Property(e => e.Component)
//                    .HasMaxLength(256)
//                    .HasComment("前端组件");

//                entity.Property(e => e.CreatedTime).HasComment("创建时间");

//                entity.Property(e => e.CreatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("创建用户Id");

//                entity.Property(e => e.Icon)
//                    .HasMaxLength(128)
//                    .HasComment("图标");

//                entity.Property(e => e.IsDeleted)
//                    .IsRequired()
//                    .HasDefaultValueSql("(CONVERT([bit],(0)))")
//                    .HasComment("软删标记");

//                entity.Property(e => e.IsEnabled).HasComment("启用状态");

//                entity.Property(e => e.Link)
//                    .HasMaxLength(1024)
//                    .HasComment("内链地址");

//                entity.Property(e => e.Name)
//                    .HasMaxLength(128)
//                    .HasComment("名称");

//                entity.Property(e => e.OpenType).HasComment("打开方式（0-无，1-组件，2-内链，3-外链）");

//                entity.Property(e => e.ParentId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("父级Id");

//                entity.Property(e => e.Permission)
//                    .HasMaxLength(256)
//                    .HasComment("权限标识");

//                entity.Property(e => e.Redirect)
//                    .HasMaxLength(2048)
//                    .HasComment("重定向地址");

//                entity.Property(e => e.Remark)
//                    .HasMaxLength(2048)
//                    .HasComment("备注");

//                entity.Property(e => e.Router)
//                    .HasMaxLength(256)
//                    .HasComment("路由地址");

//                entity.Property(e => e.Sort).HasComment("排序");

//                entity.Property(e => e.Type).HasComment("菜单类型（0-目录，1-菜单，2-按钮）");

//                entity.Property(e => e.UpdatedTime).HasComment("更新时间");

//                entity.Property(e => e.UpdatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("更新用户Id");

//                entity.Property(e => e.Visible).HasComment("是否可见（Y-是，N-否）");

//                entity.Property(e => e.Weight).HasComment("权重（1-系统权重，2-业务权重）");
//            });

//            modelBuilder.Entity<SysOrganization>(entity =>
//            {
//                entity.ToTable("SysOrganization");

//                entity.HasComment("组织表");

//                entity.Property(e => e.Id)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("主键");

//                entity.Property(e => e.Code)
//                    .HasMaxLength(128)
//                    .HasComment("编码");

//                entity.Property(e => e.CreatedTime).HasComment("创建时间");

//                entity.Property(e => e.CreatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("创建用户Id");

//                entity.Property(e => e.IsDeleted)
//                    .IsRequired()
//                    .HasDefaultValueSql("(CONVERT([bit],(0)))")
//                    .HasComment("软删标记");

//                entity.Property(e => e.IsEnabled).HasComment("启用状态");

//                entity.Property(e => e.Name)
//                    .HasMaxLength(128)
//                    .HasComment("名称");

//                entity.Property(e => e.ParentId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("父级Id");

//                entity.Property(e => e.Remark)
//                    .HasMaxLength(2048)
//                    .HasComment("备注");

//                entity.Property(e => e.Sort).HasComment("排序");

//                entity.Property(e => e.UpdatedTime).HasComment("更新时间");

//                entity.Property(e => e.UpdatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("更新用户Id");
//            });

//            modelBuilder.Entity<SysPosition>(entity =>
//            {
//                entity.ToTable("SysPosition");

//                entity.HasComment("岗位表");

//                entity.Property(e => e.Id)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("主键");

//                entity.Property(e => e.Code)
//                    .HasMaxLength(128)
//                    .HasComment("编码");

//                entity.Property(e => e.CreatedTime).HasComment("创建时间");

//                entity.Property(e => e.CreatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("创建用户Id");

//                entity.Property(e => e.IsDeleted)
//                    .IsRequired()
//                    .HasDefaultValueSql("(CONVERT([bit],(0)))")
//                    .HasComment("软删标记");

//                entity.Property(e => e.IsEnabled).HasComment("启用状态");

//                entity.Property(e => e.Name)
//                    .HasMaxLength(128)
//                    .HasComment("名称");

//                entity.Property(e => e.Remark)
//                    .HasMaxLength(2048)
//                    .HasComment("备注");

//                entity.Property(e => e.Sort).HasComment("排序");

//                entity.Property(e => e.UpdatedTime).HasComment("更新时间");

//                entity.Property(e => e.UpdatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("更新用户Id");
//            });

//            modelBuilder.Entity<SysRole>(entity =>
//            {
//                entity.ToTable("SysRole");

//                entity.HasComment("角色表");

//                entity.Property(e => e.Id)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("主键");

//                entity.Property(e => e.Code)
//                    .HasMaxLength(128)
//                    .HasComment("编码");

//                entity.Property(e => e.CreatedTime).HasComment("创建时间");

//                entity.Property(e => e.CreatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("创建用户Id");

//                entity.Property(e => e.DataScope)
//                    .HasDefaultValueSql("((1))")
//                    .HasComment("数据范围（1-全部数据，2-本部门及以下数据，3-本部门数据，4-仅本人数据，5-自定义数据）");

//                entity.Property(e => e.IsDeleted)
//                    .IsRequired()
//                    .HasDefaultValueSql("(CONVERT([bit],(0)))")
//                    .HasComment("软删标记");

//                entity.Property(e => e.IsEnabled).HasComment("启用状态");

//                entity.Property(e => e.Name)
//                    .HasMaxLength(128)
//                    .HasComment("名称");

//                entity.Property(e => e.Remark)
//                    .HasMaxLength(2048)
//                    .HasComment("备注");

//                entity.Property(e => e.Sort).HasComment("排序");

//                entity.Property(e => e.UpdatedTime).HasComment("更新时间");

//                entity.Property(e => e.UpdatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("更新用户Id");

//                entity.HasMany(d => d.Menus)
//                    .WithMany(p => p.Roles)
//                    .UsingEntity<Dictionary<string, object>>(
//                        "SysRoleMenu",
//                        l => l.HasOne<SysMenu>().WithMany().HasForeignKey("MenuId"),
//                        r => r.HasOne<SysRole>().WithMany().HasForeignKey("RoleId"),
//                        j =>
//                        {
//                            j.HasKey("RoleId", "MenuId");

//                            j.ToTable("SysRoleMenu").HasComment("角色菜单关联表");

//                            j.HasIndex(new[] { "MenuId", "RoleId" }, "IX_SysRoleMenu_MenuId_RoleId");

//                            j.IndexerProperty<string>("RoleId").HasMaxLength(36).IsUnicode(false).IsFixedLength().HasComment("角色Id");

//                            j.IndexerProperty<string>("MenuId").HasMaxLength(36).IsUnicode(false).IsFixedLength().HasComment("菜单Id");
//                        });

//                entity.HasMany(d => d.Organizations)
//                    .WithMany(p => p.Roles)
//                    .UsingEntity<Dictionary<string, object>>(
//                        "SysRoleDataScope",
//                        l => l.HasOne<SysOrganization>().WithMany().HasForeignKey("OrganizationId"),
//                        r => r.HasOne<SysRole>().WithMany().HasForeignKey("RoleId"),
//                        j =>
//                        {
//                            j.HasKey("RoleId", "OrganizationId");

//                            j.ToTable("SysRoleDataScope");

//                            j.HasIndex(new[] { "OrganizationId", "RoleId" }, "IX_SysRoleDataScope_OrganizationId_RoleId");

//                            j.IndexerProperty<string>("RoleId").HasMaxLength(36).IsUnicode(false).IsFixedLength().HasComment("角色Id");

//                            j.IndexerProperty<string>("OrganizationId").HasMaxLength(36).IsUnicode(false).IsFixedLength().HasComment("组织Id");
//                        });
//            });

//            modelBuilder.Entity<SysUser>(entity =>
//            {
//                entity.ToTable("SysUser");

//                entity.HasComment("用户表");

//                entity.HasIndex(e => e.OrganizationId, "IX_SysUser_OrganizationId");

//                entity.HasIndex(e => e.PositionId, "IX_SysUser_PositionId");

//                entity.HasIndex(e => e.UserName, "IX_SysUser_UserName")
//                    .IsUnique();

//                entity.Property(e => e.Id)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("主键");

//                entity.Property(e => e.AdminType)
//                    .HasDefaultValueSql("((3))")
//                    .HasComment("账号类型（1-超级管理员，2-管理员，3-普通账号）");

//                entity.Property(e => e.CreatedTime).HasComment("创建时间");

//                entity.Property(e => e.CreatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("创建用户Id");

//                entity.Property(e => e.Email)
//                    .HasMaxLength(64)
//                    .HasComment("邮件");

//                entity.Property(e => e.Gender).HasComment("性别：1-男，2-女");

//                entity.Property(e => e.IsDeleted)
//                    .IsRequired()
//                    .HasDefaultValueSql("(CONVERT([bit],(0)))")
//                    .HasComment("软删标记");

//                entity.Property(e => e.IsEnabled).HasComment("启用状态");

//                entity.Property(e => e.Name)
//                    .HasMaxLength(32)
//                    .HasComment("姓名");

//                entity.Property(e => e.OrganizationId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("主部门Id");

//                entity.Property(e => e.Password)
//                    .HasMaxLength(64)
//                    .HasComment("密码");

//                entity.Property(e => e.Phone)
//                    .HasMaxLength(16)
//                    .HasComment("手机号码");

//                entity.Property(e => e.PositionId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("主岗位Id");

//                entity.Property(e => e.UpdatedTime).HasComment("更新时间");

//                entity.Property(e => e.UpdatedUserId)
//                    .HasMaxLength(36)
//                    .IsUnicode(false)
//                    .IsFixedLength()
//                    .HasComment("更新用户Id");

//                entity.Property(e => e.UserName)
//                    .HasMaxLength(64)
//                    .HasComment("用户名");

//                entity.HasOne(d => d.Organization)
//                    .WithMany(p => p.SysUsers)
//                    .HasForeignKey(d => d.OrganizationId)
//                    .OnDelete(DeleteBehavior.SetNull);

//                entity.HasOne(d => d.Position)
//                    .WithMany(p => p.SysUsers)
//                    .HasForeignKey(d => d.PositionId)
//                    .OnDelete(DeleteBehavior.SetNull);

//                entity.HasMany(d => d.Organizations)
//                    .WithMany(p => p.Users)
//                    .UsingEntity<Dictionary<string, object>>(
//                        "SysUserDataScope",
//                        l => l.HasOne<SysOrganization>().WithMany().HasForeignKey("OrganizationId"),
//                        r => r.HasOne<SysUser>().WithMany().HasForeignKey("UserId"),
//                        j =>
//                        {
//                            j.HasKey("UserId", "OrganizationId");

//                            j.ToTable("SysUserDataScope");

//                            j.HasIndex(new[] { "OrganizationId", "UserId" }, "IX_SysUserDataScope_OrganizationId_UserId");

//                            j.IndexerProperty<string>("UserId").HasMaxLength(36).IsUnicode(false).IsFixedLength().HasComment("用户Id");

//                            j.IndexerProperty<string>("OrganizationId").HasMaxLength(36).IsUnicode(false).IsFixedLength().HasComment("组织Id");
//                        });

//                entity.HasMany(d => d.Roles)
//                    .WithMany(p => p.Users)
//                    .UsingEntity<Dictionary<string, object>>(
//                        "SysUserRole",
//                        l => l.HasOne<SysRole>().WithMany().HasForeignKey("RoleId"),
//                        r => r.HasOne<SysUser>().WithMany().HasForeignKey("UserId"),
//                        j =>
//                        {
//                            j.HasKey("UserId", "RoleId");

//                            j.ToTable("SysUserRole").HasComment("用户角色关联表");

//                            j.HasIndex(new[] { "RoleId", "UserId" }, "IX_SysUserRole_RoleId_UserId");

//                            j.IndexerProperty<string>("UserId").HasMaxLength(36).IsUnicode(false).IsFixedLength().HasComment("用户Id");

//                            j.IndexerProperty<string>("RoleId").HasMaxLength(36).IsUnicode(false).IsFixedLength().HasComment("角色Id");
//                        });
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
