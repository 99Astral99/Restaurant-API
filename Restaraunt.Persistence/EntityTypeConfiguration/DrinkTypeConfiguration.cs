using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Persistence.EntityTypeConfiguration
{
	public class DrinkTypeConfiguration : IEntityTypeConfiguration<Drink>
	{
		public void Configure(EntityTypeBuilder<Drink> builder)
		{
			builder.Property(x => x.Size).HasMaxLength(1500);

			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.Id).IsUnique();
			builder.Property(x => x.Name).HasMaxLength(50);
			builder.Property(x => x.Description).HasMaxLength(700);

			builder.HasData(new Drink
			{
				Id = 1,
				Name = "Capuccino",
				Description = "A fragrant coffee drink with a delicate milk foam.",
				Price = 1.75,
				Size = 100,
				IsCarbonated = false,
			});

			builder.HasData(new Drink
			{
				Id = 2,
				Name = "Coffee glace",
				Description = "Natural freshly brewed coffee with ice cream.",
				Price = 1.55,
				Size = 100,
				IsCarbonated = false,
			});

			builder.HasData(new Drink
			{
				Id = 3,
				Name = "Beer",
				Description = "A reall fresh beer.",
				Price = 3,
				Size = 500,
				IsCarbonated = true,
			});
		}
	}
}
