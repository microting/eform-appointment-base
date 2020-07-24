﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.AppointmentBase.Migrations
{
    public partial class RemoveBrokenForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissions_FK_Plugi",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginPermissions_PermissionId",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.DropIndex(
                name: "IX_PluginGroupPermissionVersions_PermissionId",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.DropColumn(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                column: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_PermissionId",
                table: "PluginGroupPermissionVersions",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                column: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                principalTable: "PluginGroupPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginPermissions_PermissionId",
                table: "PluginGroupPermissionVersions",
                column: "PermissionId",
                principalTable: "PluginPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
