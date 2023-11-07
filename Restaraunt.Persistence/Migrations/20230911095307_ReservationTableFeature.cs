using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaraunt.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReservationTableFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservationTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    IsReserved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingTableOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReservationTableId = table.Column<int>(type: "integer", nullable: false),
                    TableNumber = table.Column<int>(type: "integer", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: false),
                    ReservedPeopleAmount = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTableOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingTableOrders_ReservationTables_ReservationTableId",
                        column: x => x.ReservationTableId,
                        principalTable: "ReservationTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ReservationTables",
                columns: new[] { "Id", "IsReserved", "Number" },
                values: new object[,]
                {
                    { 1, false, 1 },
                    { 2, false, 2 },
                    { 3, false, 3 },
                    { 4, false, 4 },
                    { 5, false, 5 },
                    { 6, false, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingTableOrders_ReservationTableId",
                table: "BookingTableOrders",
                column: "ReservationTableId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTables_Number",
                table: "ReservationTables",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTableOrders");

            migrationBuilder.DropTable(
                name: "ReservationTables");
        }
    }
}
