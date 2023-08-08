using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaraunt.Persistence.Migrations
{
	/// <inheritdoc />
	public partial class ChangedOrderProductIdType : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn("ProductId", "Orders");

			migrationBuilder.AddColumn<Guid>("ProductId", "Orders", nullable: false, defaultValue: Guid.NewGuid());

		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn("ProductId", "Orders");

			migrationBuilder.AddColumn<int>("ProductId", "Orders", nullable: false);
		}
	}
}
