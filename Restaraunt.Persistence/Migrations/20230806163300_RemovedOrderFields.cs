using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaraunt.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOrderFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Orders",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ProductPrice",
                table: "Orders",
                type: "double precision",
                maxLength: 50000,
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
