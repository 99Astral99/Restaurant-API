using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaraunt.Persistence.Migrations
{
	/// <inheritdoc />
	public partial class IdToGuide : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Burgers",
				keyColumn: "Id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "Burgers",
				keyColumn: "Id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "Burgers",
				keyColumn: "Id",
				keyValue: 3);

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

			migrationBuilder.DeleteData(
				table: "Drinks",
				keyColumn: "Id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "Drinks",
				keyColumn: "Id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "Drinks",
				keyColumn: "Id",
				keyValue: 3);

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

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Drinks",
				type: "character varying(100)",
				maxLength: 100,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "character varying(50)",
				oldMaxLength: 50);

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Drinks",
				type: "character varying(1500)",
				maxLength: 1500,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "character varying(700)",
				oldMaxLength: 700);

			migrationBuilder.DropPrimaryKey("PK_Drinks", "Drinks");
			migrationBuilder.DropColumn("Id", "Drinks");

			migrationBuilder.AddColumn<Guid>("Id", "Drinks", nullable: false, defaultValue: Guid.NewGuid()); ;
			migrationBuilder.AddPrimaryKey("PK_Drinks", "Drinks", "Id");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Burgers",
				type: "character varying(100)",
				maxLength: 100,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "character varying(50)",
				oldMaxLength: 50);

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Burgers",
				type: "character varying(1500)",
				maxLength: 1500,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "character varying(700)",
				oldMaxLength: 700);

			migrationBuilder.DropPrimaryKey("PK_Burgers", "Burgers");
			migrationBuilder.DropColumn("Id", "Burgers");

			migrationBuilder.AddColumn<Guid>("Id", "Burgers", nullable: false, defaultValue: Guid.NewGuid()); ;
			migrationBuilder.AddPrimaryKey("PK_Burgers", "Burgers", "Id");

			migrationBuilder.InsertData(
				table: "Burgers",
				columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
				values: new object[,]
				{
					{ new Guid("0de4632b-abba-4f16-9c64-c3f6f6396ee0"), "A hot topic! Tartare sauce and burning tomato sauce emphasize the taste of juicy chicken with Parmesan cheese in a special way! And inside there are fresh tomatoes, Iceberg lettuce, chopped onion — on a potato bun with sesame seeds.", "Spicy Chicken Tar-Tar", 2.21, 217 },
					{ new Guid("1dbdcbb4-b14b-4773-9fcc-f684e63d15cd"), "Whopper - is delicious 100% beef cooked on fire with juicy tomatoes, fresh chopped lettuce, thick mayonnaise, crispy pickled cucumbers and fresh onions on a tender sesame bun.", "Triple Whopper", 4.0, 426 },
					{ new Guid("402fa84e-a92d-45d5-b2e1-19f4e231ca3b"), "A hot topic! Signature 100% beef steak under a blanket of melting Tilsiter with a generous portion of very cheesy Parmeggiano sauce and hot tomato sauce. And fresh vegetables: tomatoes, Iceberg lettuce and onions — for more juiciness. Everything is on our favorite buns with a cheese blot!", "Sharp Tilsiter King", 3.5299999999999998, 337 },
					{ new Guid("6cc3e8da-f14a-4c3e-b015-91878b3fcfc0"), "Chicken lovers will appreciate the novelty Caesar King! Juicy crispy chicken nuggets, fresh tomato and lettuce are seasoned with Caesar sauce and served on a browned sesame bun.", "Caesar King", 1.3300000000000001, 105 },
					{ new Guid("dd35db4e-17ee-4726-a4aa-a1758d21ae24"), "This is a spicy version of juicy Grand Cheese — with a burning sauce instead of ketchup! Homemade beef steak with the addition of juicy chicken — in your favorite combination with Cheddar cheese, pickled cucumbers, onions, mustard and spicy tomato sauce on a browned sesame bun!", "Spicy Grand Cheese", 2.3199999999999998, 171 },
					{ new Guid("f33ed3fa-22b5-4380-be4c-7ef1e5731f42"), "Enjoy every cheese vinegar! Delicate marble Aberdeen Angus steak, spicy Parmesan and a generous portion of Parmeggiano sauce! And inside the Romano salad, pickled red onion and fresh tomatoes on a soft brioche bun.", "Angus Parmigiano", 4.4199999999999999, 320 }
				});

			migrationBuilder.InsertData(
				table: "Drinks",
				columns: new[] { "Id", "Description", "IsCarbonated", "Name", "Price", "Size" },
				values: new object[,]
				{
					{ new Guid("386e32b2-4e94-4e2b-a993-9c4465e2af71"), "A fragrant coffee drink with a delicate milk foam.", false, "Capuccino", 1.75, 100 },
					{ new Guid("bf4027a2-db69-4284-adfe-bf4db7b1822a"), "Natural freshly brewed coffee with ice cream.", false, "Coffee glace", 1.55, 100 },
					{ new Guid("e07ea736-9d72-4594-a1dc-4eab4c49b6ef"), "A reall fresh beer.", true, "Beer", 3.0, 500 }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Burgers",
				keyColumn: "Id",
				keyValue: new Guid("0de4632b-abba-4f16-9c64-c3f6f6396ee0"));

			migrationBuilder.DeleteData(
				table: "Burgers",
				keyColumn: "Id",
				keyValue: new Guid("1dbdcbb4-b14b-4773-9fcc-f684e63d15cd"));

			migrationBuilder.DeleteData(
				table: "Burgers",
				keyColumn: "Id",
				keyValue: new Guid("402fa84e-a92d-45d5-b2e1-19f4e231ca3b"));

			migrationBuilder.DeleteData(
				table: "Burgers",
				keyColumn: "Id",
				keyValue: new Guid("6cc3e8da-f14a-4c3e-b015-91878b3fcfc0"));

			migrationBuilder.DeleteData(
				table: "Burgers",
				keyColumn: "Id",
				keyValue: new Guid("dd35db4e-17ee-4726-a4aa-a1758d21ae24"));

			migrationBuilder.DeleteData(
				table: "Burgers",
				keyColumn: "Id",
				keyValue: new Guid("f33ed3fa-22b5-4380-be4c-7ef1e5731f42"));

			migrationBuilder.DeleteData(
				table: "Drinks",
				keyColumn: "Id",
				keyValue: new Guid("386e32b2-4e94-4e2b-a993-9c4465e2af71"));

			migrationBuilder.DeleteData(
				table: "Drinks",
				keyColumn: "Id",
				keyValue: new Guid("bf4027a2-db69-4284-adfe-bf4db7b1822a"));

			migrationBuilder.DeleteData(
				table: "Drinks",
				keyColumn: "Id",
				keyValue: new Guid("e07ea736-9d72-4594-a1dc-4eab4c49b6ef"));

			migrationBuilder.DropColumn(
				name: "ProductName",
				table: "Orders");

			migrationBuilder.DropColumn(
				name: "ProductPrice",
				table: "Orders");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Drinks",
				type: "character varying(50)",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "character varying(100)",
				oldMaxLength: 100);

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Drinks",
				type: "character varying(700)",
				maxLength: 700,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "character varying(1500)",
				oldMaxLength: 1500);

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Drinks",
				type: "integer",
				nullable: false,
				oldClrType: typeof(Guid),
				oldType: "uuid")
				.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

			migrationBuilder.DropPrimaryKey("PK_Drinks", "Drinks");
			migrationBuilder.DropColumn("Id", "Drinks");

			migrationBuilder.AddColumn<int>(
				name: "Id",
				table: "Drinks",
				type: "integer",
				nullable: false)
				.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

			migrationBuilder.AddPrimaryKey("PK_Drinks", "Drinks", "Id");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Burgers",
				type: "character varying(50)",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "character varying(100)",
				oldMaxLength: 100);

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Burgers",
				type: "character varying(700)",
				maxLength: 700,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "character varying(1500)",
				oldMaxLength: 1500);

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Burgers",
				type: "integer",
				nullable: false,
				oldClrType: typeof(Guid),
				oldType: "uuid")
				.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);


			migrationBuilder.DropPrimaryKey("PK_Burgers", "Burgers");
			migrationBuilder.DropColumn("Id", "Burgers");

			migrationBuilder.AddColumn<int>(
				name: "Id",
				table: "Burgers",
				type: "integer",
				nullable: false)
				.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

			migrationBuilder.AddPrimaryKey("PK_Burgers", "Burgers", "Id");

			migrationBuilder.InsertData(
				table: "Burgers",
				columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
				values: new object[,]
				{
					{ 1, "Chicken lovers will appreciate the novelty Caesar King! Juicy crispy chicken nuggets, fresh tomato and lettuce are seasoned with Caesar sauce and served on a browned sesame bun.", "Caesar King", 1.3300000000000001, 105 },
					{ 2, "This is a spicy version of juicy Grand Cheese — with a burning sauce instead of ketchup! Homemade beef steak with the addition of juicy chicken — in your favorite combination with Cheddar cheese, pickled cucumbers, onions, mustard and spicy tomato sauce on a browned sesame bun!", "Spicy Grand Cheese", 2.3199999999999998, 171 },
					{ 3, "Whopper - is delicious 100% beef cooked on fire with juicy tomatoes, fresh chopped lettuce, thick mayonnaise, crispy pickled cucumbers and fresh onions on a tender sesame bun.", "Triple Whopper", 4.0, 426 },
					{ 4, "A hot topic! Tartare sauce and burning tomato sauce emphasize the taste of juicy chicken with Parmesan cheese in a special way! And inside there are fresh tomatoes, Iceberg lettuce, chopped onion — on a potato bun with sesame seeds.", "Spicy Chicken Tar-Tar", 2.21, 217 },
					{ 5, "Enjoy every cheese vinegar! Delicate marble Aberdeen Angus steak, spicy Parmesan and a generous portion of Parmeggiano sauce! And inside the Romano salad, pickled red onion and fresh tomatoes on a soft brioche bun.", "Angus Parmigiano", 4.4199999999999999, 320 },
					{ 6, "A hot topic! Signature 100% beef steak under a blanket of melting Tilsiter with a generous portion of very cheesy Parmeggiano sauce and hot tomato sauce. And fresh vegetables: tomatoes, Iceberg lettuce and onions — for more juiciness. Everything is on our favorite buns with a cheese blot!", "Sharp Tilsiter King", 3.5299999999999998, 337 }
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
		}
	}
}
