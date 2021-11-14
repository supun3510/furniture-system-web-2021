using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace furniture_system_web.Migrations
{
    public partial class adddatetimecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quentity",
                table: "stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "productions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "checkProductions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_Date",
                table: "checkProductions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "cashProductions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_Date",
                table: "cashProductions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "cardProductions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_Date",
                table: "cardProductions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "productions");

            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "checkProductions");

            migrationBuilder.DropColumn(
                name: "Created_Date",
                table: "checkProductions");

            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "cashProductions");

            migrationBuilder.DropColumn(
                name: "Created_Date",
                table: "cashProductions");

            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "cardProductions");

            migrationBuilder.DropColumn(
                name: "Created_Date",
                table: "cardProductions");

            migrationBuilder.AlterColumn<string>(
                name: "Quentity",
                table: "stocks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
