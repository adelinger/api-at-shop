using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiatshop.Migrations
{
    /// <inheritdoc />
    public partial class fixOrderTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "VariantID",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VariantID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
