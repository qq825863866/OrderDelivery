// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ods.EntityFrameworkCore.Host;

#nullable disable

namespace Ods.EntityFrameworkCore.Host.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    partial class MigrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ods.Repository.Models.System.SysApplication", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(36)")
                        .HasComment("主键");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("编码");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<string>("CreatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("创建用户Id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("是否激活（只能同时激活一个应用）。");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("软删标记");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasComment("启用状态");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("备注");

                    b.Property<int>("Sort")
                        .HasColumnType("int")
                        .HasComment("排序");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("更新时间");

                    b.Property<string>("UpdatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("更新用户Id");

                    b.HasKey("Id");

                    b.ToTable("SysApplication");

                    b.HasComment("应用表");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysMenu", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(36)")
                        .HasComment("主键");

                    b.Property<string>("Application")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("应用分类");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("编码");

                    b.Property<string>("Component")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasComment("前端组件");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<string>("CreatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("创建用户Id");

                    b.Property<string>("Icon")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("图标");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("软删标记");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasComment("启用状态");

                    b.Property<string>("Link")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasComment("内链地址");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("名称");

                    b.Property<int>("OpenType")
                        .HasColumnType("int")
                        .HasComment("打开方式（0-无，1-组件，2-内链，3-外链）");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("父级Id");

                    b.Property<string>("Permission")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasComment("权限标识");

                    b.Property<string>("Redirect")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("重定向地址");

                    b.Property<string>("Remark")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("备注");

                    b.Property<string>("Router")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasComment("路由地址");

                    b.Property<int>("Sort")
                        .HasColumnType("int")
                        .HasComment("排序");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasComment("菜单类型（0-目录，1-菜单，2-按钮）");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("更新时间");

                    b.Property<string>("UpdatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("更新用户Id");

                    b.Property<string>("Visible")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("是否可见（Y-是，N-否）");

                    b.Property<int>("Weight")
                        .HasColumnType("int")
                        .HasComment("权重（1-系统权重，2-业务权重）");

                    b.HasKey("Id");

                    b.ToTable("SysMenu");

                    b.HasComment("菜单表");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysOrganization", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(36)")
                        .HasComment("主键");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("编码");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<string>("CreatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("创建用户Id");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("软删标记");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasComment("启用状态");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("名称");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("父级Id");

                    b.Property<string>("Remark")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("备注");

                    b.Property<int>("Sort")
                        .HasColumnType("int")
                        .HasComment("排序");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("更新时间");

                    b.Property<string>("UpdatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("更新用户Id");

                    b.HasKey("Id");

                    b.ToTable("SysOrganization");

                    b.HasComment("组织表");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysPosition", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(36)")
                        .HasComment("主键");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("编码");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<string>("CreatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("创建用户Id");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("软删标记");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasComment("启用状态");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("备注");

                    b.Property<int>("Sort")
                        .HasColumnType("int")
                        .HasComment("排序");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("更新时间");

                    b.Property<string>("UpdatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("更新用户Id");

                    b.HasKey("Id");

                    b.ToTable("SysPosition");

                    b.HasComment("岗位表");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(36)")
                        .HasComment("主键");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("编码");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<string>("CreatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("创建用户Id");

                    b.Property<int>("DataScope")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasComment("数据范围（1-全部数据，2-本部门及以下数据，3-本部门数据，4-仅本人数据，5-自定义数据）");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("软删标记");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasComment("启用状态");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("备注");

                    b.Property<long>("RowVersion")
                        .IsConcurrencyToken()
                        .HasColumnType("bigint");

                    b.Property<int>("Sort")
                        .HasColumnType("int")
                        .HasComment("排序");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("更新时间");

                    b.Property<string>("UpdatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("更新用户Id");

                    b.HasKey("Id");

                    b.ToTable("SysRole");

                    b.HasComment("角色表");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysRoleDataScope", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("char(36)")
                        .HasComment("角色Id");

                    b.Property<string>("OrganizationId")
                        .HasColumnType("char(36)")
                        .HasComment("组织Id");

                    b.HasKey("RoleId", "OrganizationId");

                    b.HasIndex("OrganizationId", "RoleId");

                    b.ToTable("SysRoleDataScope");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysRoleMenu", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("char(36)")
                        .HasComment("角色Id");

                    b.Property<string>("MenuId")
                        .HasColumnType("char(36)")
                        .HasComment("菜单Id");

                    b.HasKey("RoleId", "MenuId");

                    b.HasIndex("MenuId", "RoleId");

                    b.ToTable("SysRoleMenu");

                    b.HasComment("角色菜单关联表");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(36)")
                        .HasComment("主键");

                    b.Property<int>("AdminType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3)
                        .HasComment("账号类型（1-超级管理员，2-管理员，3-普通账号）");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<string>("CreatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("创建用户Id");

                    b.Property<string>("Email")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasComment("邮件");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasComment("性别：1-男，2-女");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("软删标记");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasComment("启用状态");

                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasComment("姓名");

                    b.Property<string>("OrganizationId")
                        .HasColumnType("char(36)")
                        .HasComment("主部门Id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasComment("密码");

                    b.Property<string>("Phone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasComment("手机号码");

                    b.Property<string>("PositionId")
                        .HasColumnType("char(36)")
                        .HasComment("主岗位Id");

                    b.Property<long>("RowVersion")
                        .IsConcurrencyToken()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasComment("更新时间");

                    b.Property<string>("UpdatedUserId")
                        .HasColumnType("char(36)")
                        .HasComment("更新用户Id");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasComment("用户名");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PositionId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("SysUser");

                    b.HasComment("用户表");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysUserDataScope", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("char(36)")
                        .HasComment("用户Id");

                    b.Property<string>("OrganizationId")
                        .HasColumnType("char(36)")
                        .HasComment("组织Id");

                    b.HasKey("UserId", "OrganizationId");

                    b.HasIndex("OrganizationId", "UserId");

                    b.ToTable("SysUserDataScope");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("char(36)")
                        .HasComment("用户Id");

                    b.Property<string>("RoleId")
                        .HasColumnType("char(36)")
                        .HasComment("角色Id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId", "UserId");

                    b.ToTable("SysUserRole");

                    b.HasComment("用户角色关联表");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysRoleDataScope", b =>
                {
                    b.HasOne("Ods.Repository.Models.System.SysOrganization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ods.Repository.Models.System.SysRole", "Role")
                        .WithMany("RoleDataScopes")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysRoleMenu", b =>
                {
                    b.HasOne("Ods.Repository.Models.System.SysMenu", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ods.Repository.Models.System.SysRole", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysUser", b =>
                {
                    b.HasOne("Ods.Repository.Models.System.SysOrganization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Ods.Repository.Models.System.SysPosition", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Organization");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysUserDataScope", b =>
                {
                    b.HasOne("Ods.Repository.Models.System.SysOrganization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ods.Repository.Models.System.SysUser", "User")
                        .WithMany("UserDataScopes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysUserRole", b =>
                {
                    b.HasOne("Ods.Repository.Models.System.SysRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ods.Repository.Models.System.SysUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysMenu", b =>
                {
                    b.Navigation("RoleMenus");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysRole", b =>
                {
                    b.Navigation("RoleDataScopes");

                    b.Navigation("RoleMenus");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Ods.Repository.Models.System.SysUser", b =>
                {
                    b.Navigation("UserDataScopes");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
