using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ods.EntityFrameworkCore.Host.Migrations
{
    public partial class init_20221026 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysApplication",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "主键"),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "编码"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "备注"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用状态"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "是否激活（只能同时激活一个应用）。"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "软删标记"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "创建用户Id"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    UpdatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "更新用户Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysApplication", x => x.Id);
                },
                comment: "应用表");

            migrationBuilder.CreateTable(
                name: "SysMenu",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "主键"),
                    ParentId = table.Column<string>(type: "char(36)", nullable: false, comment: "父级Id"),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "编码"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    Application = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true, comment: "应用分类"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "菜单类型（0-目录，1-菜单，2-按钮）"),
                    OpenType = table.Column<int>(type: "int", nullable: false, comment: "打开方式（0-无，1-组件，2-内链，3-外链）"),
                    Icon = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true, comment: "图标"),
                    Component = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "前端组件"),
                    Router = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "路由地址"),
                    Permission = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "权限标识"),
                    Visible = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "是否可见（Y-是，N-否）"),
                    Link = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true, comment: "内链地址"),
                    Redirect = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "重定向地址"),
                    Weight = table.Column<int>(type: "int", nullable: false, comment: "权重（1-系统权重，2-业务权重）"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "备注"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用状态"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "软删标记"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "创建用户Id"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    UpdatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "更新用户Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.Id);
                },
                comment: "菜单表");

            migrationBuilder.CreateTable(
                name: "SysOrganization",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "主键"),
                    ParentId = table.Column<string>(type: "char(36)", nullable: false, comment: "父级Id"),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "编码"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用状态"),
                    Remark = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "备注"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "软删标记"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "创建用户Id"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    UpdatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "更新用户Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysOrganization", x => x.Id);
                },
                comment: "组织表");

            migrationBuilder.CreateTable(
                name: "SysPosition",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "主键"),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "编码"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "备注"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用状态"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "软删标记"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "创建用户Id"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    UpdatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "更新用户Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysPosition", x => x.Id);
                },
                comment: "岗位表");

            migrationBuilder.CreateTable(
                name: "SysRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "主键"),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "编码"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "备注"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用状态"),
                    DataScope = table.Column<int>(type: "int", nullable: false, defaultValue: 1, comment: "数据范围（1-全部数据，2-本部门及以下数据，3-本部门数据，4-仅本人数据，5-自定义数据）"),
                    RowVersion = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "软删标记"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "创建用户Id"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    UpdatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "更新用户Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.Id);
                },
                comment: "角色表");

            migrationBuilder.CreateTable(
                name: "SysUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "主键"),
                    UserName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "用户名"),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "密码"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "姓名"),
                    Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true, comment: "手机号码"),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "邮件"),
                    Gender = table.Column<int>(type: "int", nullable: false, comment: "性别：1-男，2-女"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用状态"),
                    PositionId = table.Column<string>(type: "char(36)", nullable: true, comment: "主岗位Id"),
                    OrganizationId = table.Column<string>(type: "char(36)", nullable: true, comment: "主部门Id"),
                    AdminType = table.Column<int>(type: "int", nullable: false, defaultValue: 3, comment: "账号类型（1-超级管理员，2-管理员，3-普通账号）"),
                    RowVersion = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "软删标记"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "创建用户Id"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    UpdatedUserId = table.Column<string>(type: "char(36)", nullable: true, comment: "更新用户Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysUser_SysOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "SysOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SysUser_SysPosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "SysPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "用户表");

            migrationBuilder.CreateTable(
                name: "SysRoleDataScope",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "char(36)", nullable: false, comment: "角色Id"),
                    OrganizationId = table.Column<string>(type: "char(36)", nullable: false, comment: "组织Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleDataScope", x => new { x.RoleId, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_SysRoleDataScope_SysOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "SysOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysRoleDataScope_SysRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysRoleMenu",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "char(36)", nullable: false, comment: "角色Id"),
                    MenuId = table.Column<string>(type: "char(36)", nullable: false, comment: "菜单Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleMenu", x => new { x.RoleId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_SysRoleMenu_SysMenu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "SysMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysRoleMenu_SysRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色菜单关联表");

            migrationBuilder.CreateTable(
                name: "SysUserDataScope",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "char(36)", nullable: false, comment: "用户Id"),
                    OrganizationId = table.Column<string>(type: "char(36)", nullable: false, comment: "组织Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserDataScope", x => new { x.UserId, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_SysUserDataScope_SysOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "SysOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysUserDataScope_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "char(36)", nullable: false, comment: "用户Id"),
                    RoleId = table.Column<string>(type: "char(36)", nullable: false, comment: "角色Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_SysUserRole_SysRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysUserRole_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户角色关联表");

            migrationBuilder.CreateIndex(
                name: "IX_SysRoleDataScope_OrganizationId_RoleId",
                table: "SysRoleDataScope",
                columns: new[] { "OrganizationId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_SysRoleMenu_MenuId_RoleId",
                table: "SysRoleMenu",
                columns: new[] { "MenuId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_SysUser_OrganizationId",
                table: "SysUser",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUser_PositionId",
                table: "SysUser",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUser_UserName",
                table: "SysUser",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SysUserDataScope_OrganizationId_UserId",
                table: "SysUserDataScope",
                columns: new[] { "OrganizationId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_SysUserRole_RoleId_UserId",
                table: "SysUserRole",
                columns: new[] { "RoleId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysApplication");

            migrationBuilder.DropTable(
                name: "SysRoleDataScope");

            migrationBuilder.DropTable(
                name: "SysRoleMenu");

            migrationBuilder.DropTable(
                name: "SysUserDataScope");

            migrationBuilder.DropTable(
                name: "SysUserRole");

            migrationBuilder.DropTable(
                name: "SysMenu");

            migrationBuilder.DropTable(
                name: "SysRole");

            migrationBuilder.DropTable(
                name: "SysUser");

            migrationBuilder.DropTable(
                name: "SysOrganization");

            migrationBuilder.DropTable(
                name: "SysPosition");
        }
    }
}
