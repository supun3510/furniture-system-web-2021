using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace furniture_system_web.Migrations
{
    public partial class table_updates_paymenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bii_withoutDiscount",
                table: "productions");

            migrationBuilder.DropColumn(
                name: "Customer_Balence",
                table: "productions");

            migrationBuilder.DropColumn(
                name: "Customer_Bill",
                table: "productions");

            migrationBuilder.DropColumn(
                name: "Customer_Payment",
                table: "productions");

            migrationBuilder.DropColumn(
                name: "Total_Discount",
                table: "productions");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_Date",
                table: "productions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Customer_Mobile",
                table: "productions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Customer_Name",
                table: "productions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bill_Code",
                table: "ProductionCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cardProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bill_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Bill = table.Column<double>(type: "float", nullable: false),
                    Customer_Payment = table.Column<double>(type: "float", nullable: false),
                    Customer_Balence = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardProductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cashProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bill_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Bill = table.Column<double>(type: "float", nullable: false),
                    Customer_Payment = table.Column<double>(type: "float", nullable: false),
                    Customer_Balence = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashProductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "checkProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bill_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Check_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Bill = table.Column<double>(type: "float", nullable: false),
                    Customer_Payment = table.Column<double>(type: "float", nullable: false),
                    Customer_Balence = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkProductions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cardProductions");

            migrationBuilder.DropTable(
                name: "cashProductions");

            migrationBuilder.DropTable(
                name: "checkProductions");

            migrationBuilder.DropColumn(
                name: "Created_Date",
                table: "productions");

            migrationBuilder.DropColumn(
                name: "Customer_Mobile",
                table: "productions");

            migrationBuilder.DropColumn(
                name: "Customer_Name",
                table: "productions");

            migrationBuilder.DropColumn(
                name: "Bill_Code",
                table: "ProductionCarts");

            migrationBuilder.AddColumn<double>(
                name: "Bii_withoutDiscount",
                table: "productions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Customer_Balence",
                table: "productions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Customer_Bill",
                table: "productions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Customer_Payment",
                table: "productions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Total_Discount",
                table: "productions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
