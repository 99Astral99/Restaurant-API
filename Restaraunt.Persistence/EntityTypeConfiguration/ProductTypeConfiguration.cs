using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.Domain;

namespace Restaraunt.Persistence.EntityTypeConfiguration
{
	public class ProductTypeConfiguration : IEntityTypeConfiguration<BaseProduct>
	{
		public void Configure(EntityTypeBuilder<BaseProduct> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.Id).IsUnique();
			builder.Property(x => x.Name).HasMaxLength(50);
			builder.Property(x => x.Description).HasMaxLength(700);
		}
	}
}
