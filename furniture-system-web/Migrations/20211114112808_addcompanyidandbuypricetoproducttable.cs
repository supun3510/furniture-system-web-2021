using Microsoft.EntityFrameworkCore.Migrations;

namespace furniture_system_web.Migrations
{
    public partial class addcompanyidandbuypricetoproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Buy_Price",
                table: "products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Company_Id",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buy_Price",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Company_Id",
                table: "products");
        }
    }
}
