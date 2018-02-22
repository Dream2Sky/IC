using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IC.CloudLink.WebApi.Migrations
{
    public partial class CloudLinkDBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowPackageRecords",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CardId = table.Column<string>(maxLength: 36, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false),
                    PackageId = table.Column<string>(maxLength: 36, nullable: true),
                    UserId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowPackageRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowPackages",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: false),
                    Desc = table.Column<string>(maxLength: 1000, nullable: true),
                    Flow = table.Column<decimal>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReChargeRecords",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReChargeRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false),
                    Phone = table.Column<string>(maxLength: 13, nullable: true),
                    WxOpenId = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowCards",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: false),
                    ICCId = table.Column<string>(maxLength: 20, nullable: false),
                    IsDel = table.Column<bool>(nullable: false),
                    OpenId = table.Column<string>(maxLength: 32, nullable: true),
                    TotalFlow = table.Column<decimal>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UsagedFlow = table.Column<decimal>(nullable: false),
                    UserId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowCards_UserId",
                table: "FlowCards",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowCards");

            migrationBuilder.DropTable(
                name: "FlowPackageRecords");

            migrationBuilder.DropTable(
                name: "FlowPackages");

            migrationBuilder.DropTable(
                name: "ReChargeRecords");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
