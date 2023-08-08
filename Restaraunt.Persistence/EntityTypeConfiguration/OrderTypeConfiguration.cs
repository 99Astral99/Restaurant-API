using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Persistence.EntityTypeConfiguration
{
	public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Orders").HasKey(i => i.Id);
			builder.HasKey(i => i.Id);

			//builder.Property(o => o.ProductPrice).IsRequired().HasMaxLength(50000);
			//builder.Property(o => o.ProductName).IsRequired().HasMaxLength(1500);
			builder.Property(o => o.ProductId).IsRequired();

			builder.HasOne(u => u.Cart)
				.WithMany(o => o.Orders)
				.HasForeignKey(i => i.CartId);
		}
	}
}
