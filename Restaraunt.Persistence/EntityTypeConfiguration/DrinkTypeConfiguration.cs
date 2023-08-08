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
			builder.Property(x => x.Name).HasMaxLength(100);
			builder.Property(x => x.Description).HasMaxLength(1500);

			builder.HasData(new Drink
			{
				Id = new Guid("386E32B2-4E94-4E2B-A993-9C4465E2AF71"),
				Name = "Capuccino",
				Description = "A fragrant coffee drink with a delicate milk foam.",
				Price = 1.75,
				Size = 100,
				IsCarbonated = false,
			});

			builder.HasData(new Drink
			{
				Id = new Guid("BF4027A2-DB69-4284-ADFE-BF4DB7B1822A"),
				Name = "Coffee glace",
				Description = "Natural freshly brewed coffee with ice cream.",
				Price = 1.55,
				Size = 100,
				IsCarbonated = false,
			});

			builder.HasData(new Drink
			{
				Id = new Guid("E07EA736-9D72-4594-A1DC-4EAB4C49B6EF"),
				Name = "Beer",
				Description = "A reall fresh beer.",
				Price = 3,
				Size = 500,
				IsCarbonated = true,
			});
		}
	}
}
