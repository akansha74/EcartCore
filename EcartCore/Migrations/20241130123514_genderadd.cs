﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EcartCore.Migrations
{
    public partial class genderadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_City_CityId",
                table: "AppUser");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "AppUser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AppUser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_GenderId",
                table: "AppUser",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_City_CityId",
                table: "AppUser",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Gender_GenderId",
                table: "AppUser",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_City_CityId",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Gender_GenderId",
                table: "AppUser");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_GenderId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AppUser");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "AppUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_City_CityId",
                table: "AppUser",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
