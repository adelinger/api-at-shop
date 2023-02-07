using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiatshop.Migrations
{
    /// <inheritdoc />
    public partial class fixCurrenciesAgain3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "USDValue",
                table: "Currencies",
                type: "decimal(7,1)",
                precision: 7,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldPrecision: 7,
                oldScale: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "EURValue",
                table: "Currencies",
                type: "decimal(7,1)",
                precision: 7,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "USDValue",
                table: "Currencies",
                type: "money",
                precision: 7,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,1)",
                oldPrecision: 7,
                oldScale: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "EURValue",
                table: "Currencies",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,1)",
                oldPrecision: 7,
                oldScale: 1);
        }
    }
}
