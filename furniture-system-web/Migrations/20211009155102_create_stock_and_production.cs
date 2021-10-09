using Microsoft.EntityFrameworkCore.Migrations;

namespace furniture_system_web.Migrations
{
    public partial class create_stock_and_production : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Retail_Price",
                table: "products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Retail_Price",
                table: "products");
        }
    }
}
