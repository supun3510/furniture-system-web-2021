using Microsoft.EntityFrameworkCore.Migrations;

namespace furniture_system_web.Migrations
{
    public partial class change_product_cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discounted",
                table: "ProductionCarts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Item_Name",
                table: "ProductionCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Retail_Price",
                table: "ProductionCarts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discounted",
                table: "ProductionCarts");

            migrationBuilder.DropColumn(
                name: "Item_Name",
                table: "ProductionCarts");

            migrationBuilder.DropColumn(
                name: "Retail_Price",
                table: "ProductionCarts");
        }
    }
}
