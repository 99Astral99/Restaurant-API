using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaraunt.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedBurgers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Caesar King");

            migrationBuilder.InsertData(
                table: "Burgers",
                columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { 4, "A hot topic! Tartare sauce and burning tomato sauce emphasize the taste of juicy chicken with Parmesan cheese in a special way! And inside there are fresh tomatoes, Iceberg lettuce, chopped onion — on a potato bun with sesame seeds.", "Spicy Chicken Tar-Tar", 2.21, 217 },
                    { 5, "Enjoy every cheese vinegar! Delicate marble Aberdeen Angus steak, spicy Parmesan and a generous portion of Parmeggiano sauce! And inside the Romano salad, pickled red onion and fresh tomatoes on a soft brioche bun.", "Angus Parmigiano", 4.4199999999999999, 320 },
                    { 6, "A hot topic! Signature 100% beef steak under a blanket of melting Tilsiter with a generous portion of very cheesy Parmeggiano sauce and hot tomato sauce. And fresh vegetables: tomatoes, Iceberg lettuce and onions — for more juiciness. Everything is on our favorite buns with a cheese blot!", "Sharp Tilsiter King", 3.5299999999999998, 337 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Hamburger");
        }
    }
}
