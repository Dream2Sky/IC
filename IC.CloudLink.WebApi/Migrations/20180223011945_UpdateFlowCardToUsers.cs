using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IC.CloudLink.WebApi.Migrations
{
    public partial class UpdateFlowCardToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlowCardId",
                table: "FlowPackages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlowCardId",
                table: "FlowPackageRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlowPackageId",
                table: "FlowPackageRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReChargeRecords_UserId",
                table: "ReChargeRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowPackages_FlowCardId",
                table: "FlowPackages",
                column: "FlowCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowPackageRecords_FlowCardId",
                table: "FlowPackageRecords",
                column: "FlowCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowPackageRecords_FlowPackageId",
                table: "FlowPackageRecords",
                column: "FlowPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowPackageRecords_UserId",
                table: "FlowPackageRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowPackageRecords_FlowCards_FlowCardId",
                table: "FlowPackageRecords",
                column: "FlowCardId",
                principalTable: "FlowCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowPackageRecords_FlowPackages_FlowPackageId",
                table: "FlowPackageRecords",
                column: "FlowPackageId",
                principalTable: "FlowPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ReChargeRecords_Users_UserId",
                table: "ReChargeRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowPackageRecords_FlowCards_FlowCardId",
                table: "FlowPackageRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowPackageRecords_FlowPackages_FlowPackageId",
                table: "FlowPackageRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowPackageRecords_Users_UserId",
                table: "FlowPackageRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowPackages_FlowCards_FlowCardId",
                table: "FlowPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_ReChargeRecords_Users_UserId",
                table: "ReChargeRecords");

            migrationBuilder.DropIndex(
                name: "IX_ReChargeRecords_UserId",
                table: "ReChargeRecords");

            migrationBuilder.DropIndex(
                name: "IX_FlowPackages_FlowCardId",
                table: "FlowPackages");

            migrationBuilder.DropIndex(
                name: "IX_FlowPackageRecords_FlowCardId",
                table: "FlowPackageRecords");

            migrationBuilder.DropIndex(
                name: "IX_FlowPackageRecords_FlowPackageId",
                table: "FlowPackageRecords");

            migrationBuilder.DropIndex(
                name: "IX_FlowPackageRecords_UserId",
                table: "FlowPackageRecords");

            migrationBuilder.DropColumn(
                name: "FlowCardId",
                table: "FlowPackages");

            migrationBuilder.DropColumn(
                name: "FlowCardId",
                table: "FlowPackageRecords");

            migrationBuilder.DropColumn(
                name: "FlowPackageId",
                table: "FlowPackageRecords");
        }
    }
}
