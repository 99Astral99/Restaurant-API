using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Persistence.EntityTypeConfiguration
{
	public class CartTypeConfiguration : IEntityTypeConfiguration<Cart>
	{
		public void Configure(EntityTypeBuilder<Cart> builder)
		{
			builder.HasKey(c => c.Id);
		}
	}
}
