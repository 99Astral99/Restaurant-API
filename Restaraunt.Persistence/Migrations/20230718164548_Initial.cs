using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaraunt.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weight = table.Column<int>(type: "integer", maxLength: 1000, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(700)", maxLength: 700, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burgers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Size = table.Column<int>(type: "integer", maxLength: 1500, nullable: false),
                    IsCarbonated = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(700)", maxLength: 700, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Burgers",
                columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { 1, "Chicken lovers will appreciate the novelty Caesar King! Juicy crispy chicken nuggets, fresh tomato and lettuce are seasoned with Caesar sauce and served on a browned sesame bun.", "Hamburger", 1.3300000000000001, 105 },
                    { 2, "This is a spicy version of juicy Grand Cheese — with a burning sauce instead of ketchup! Homemade beef steak with the addition of juicy chicken — in your favorite combination with Cheddar cheese, pickled cucumbers, onions, mustard and spicy tomato sauce on a browned sesame bun!", "Spicy Grand Cheese", 2.3199999999999998, 171 },
                    { 3, "Whopper - is delicious 100% beef cooked on fire with juicy tomatoes, fresh chopped lettuce, thick mayonnaise, crispy pickled cucumbers and fresh onions on a tender sesame bun.", "Triple Whopper", 4.0, 426 }
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Description", "IsCarbonated", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "A fragrant coffee drink with a delicate milk foam.", false, "Capuccino", 1.75, 100 },
                    { 2, "Natural freshly brewed coffee with ice cream.", false, "Coffee glace", 1.55, 100 },
                    { 3, "A reall fresh beer.", true, "Beer", 3.0, 500 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Burgers_Id",
                table: "Burgers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_Id",
                table: "Drinks",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Burgers");

            migrationBuilder.DropTable(
                name: "Drinks");
        }
    }
}
