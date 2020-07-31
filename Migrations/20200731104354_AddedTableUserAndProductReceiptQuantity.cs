using Microsoft.EntityFrameworkCore.Migrations;

namespace RestorauntManagement.Migrations
{
    public partial class AddedTableUserAndProductReceiptQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServedBy",
                table: "Tables",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductRecepits",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServedBy",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductRecepits");
        }
    }
}
