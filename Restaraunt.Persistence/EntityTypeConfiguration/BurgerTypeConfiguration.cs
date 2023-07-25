using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.Domain;

namespace Restaraunt.Persistence.EntityTypeConfiguration
{
	public class BurgerTypeConfiguration : IEntityTypeConfiguration<Burger>
	{
		public void Configure(EntityTypeBuilder<Burger> builder)
		{
			builder.Property(x => x.Weight).HasMaxLength(1000);

			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.Id).IsUnique();
			builder.Property(x => x.Name).HasMaxLength(50);
			builder.Property(x => x.Description).HasMaxLength(700);

			builder.HasData(new Burger
			{
				Id = 1,
				Name = "Caesar King",
				Description = "Chicken lovers will appreciate the novelty Caesar King! Juicy crispy chicken nuggets, fresh tomato and lettuce are seasoned with Caesar sauce and served on a browned sesame bun.",
				Price = 1.33,
				Weight = 105,
			});

			builder.HasData(new Burger
			{
				Id = 2,
				Name = "Spicy Grand Cheese",
				Description = "This is a spicy version of juicy Grand Cheese — with a burning sauce instead of ketchup! Homemade beef steak with the addition of juicy chicken — in your favorite combination with Cheddar cheese, pickled cucumbers, onions, mustard and spicy tomato sauce on a browned sesame bun!",
				Price = 2.32,
				Weight = 171,
			});

			builder.HasData(new Burger
			{
				Id = 3,
				Name = "Triple Whopper",
				Description = "Whopper - is delicious 100% beef cooked on fire with juicy tomatoes, fresh chopped lettuce, thick mayonnaise, crispy pickled cucumbers and fresh onions on a tender sesame bun.",
				Price = 4.0,
				Weight = 426,
			});

			builder.HasData(new Burger
			{
				Id = 4,
				Name = "Spicy Chicken Tar-Tar",
				Description = "A hot topic! Tartare sauce and burning tomato sauce emphasize the taste of juicy chicken with Parmesan cheese in a special way! And inside there are fresh tomatoes, Iceberg lettuce, chopped onion — on a potato bun with sesame seeds.",
				Price = 2.21,
				Weight = 217,
			});

			builder.HasData(new Burger
			{
				Id = 5,
				Name = "Angus Parmigiano",
				Description = "Enjoy every cheese vinegar! Delicate marble Aberdeen Angus steak, spicy Parmesan and a generous portion of Parmeggiano sauce! And inside the Romano salad, pickled red onion and fresh tomatoes on a soft brioche bun.",
				Price = 4.42,
				Weight = 320,
			});

			builder.HasData(new Burger
			{
				Id = 6,
				Name = "Sharp Tilsiter King",
				Description = "A hot topic! Signature 100% beef steak under a blanket of melting Tilsiter with a generous portion of very cheesy Parmeggiano sauce and hot tomato sauce. And fresh vegetables: tomatoes, Iceberg lettuce and onions — for more juiciness. Everything is on our favorite buns with a cheese blot!",
				Price = 3.53,
				Weight = 337,
			});
		}
	}
}
