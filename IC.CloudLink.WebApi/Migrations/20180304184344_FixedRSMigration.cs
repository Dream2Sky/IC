using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IC.CloudLink.WebApi.Migrations
{
    public partial class FixedRSMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // EFCode Mysql 删除外键生成的sql有语法错误，需要手动修改迁移脚本

            //migrationBuilder.DropForeignKey(
            //    name: "FK_FlowPackageRecords_Users_UserId",
            //    table: "FlowPackageRecords");

            migrationBuilder.Sql("ALTER TABLE `FlowPackageRecords` DROP FOREIGN KEY `FK_FlowPackageRecords_Users_UserId`;");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_FlowPackages_FlowCards_FlowCardId",
            //    table: "FlowPackages");

            migrationBuilder.Sql("ALTER TABLE `FlowPackages` DROP FOREIGN KEY `FK_FlowPackages_FlowCards_FlowCardId`;");
            migrationBuilder.DropIndex(
                name: "IX_FlowPackages_FlowCardId",
                table: "FlowPackages");

            migrationBuilder.DropIndex(
                name: "IX_FlowPackageRecords_UserId",
                table: "FlowPackageRecords");

            migrationBuilder.DropColumn(
                name: "FlowCardId",
                table: "FlowPackages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FlowPackageRecords");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlowCardId",
                table: "FlowPackages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FlowPackageRecords",
                maxLength: 36,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlowPackages_FlowCardId",
                table: "FlowPackages",
                column: "FlowCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowPackageRecords_UserId",
                table: "FlowPackageRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowPackageRecords_Users_UserId",
                table: "FlowPackageRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowPackages_FlowCards_FlowCardId",
                table: "FlowPackages",
                column: "FlowCardId",
                principalTable: "FlowCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
