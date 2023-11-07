using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Persistence.EntityTypeConfiguration
{
	public class BookingTableOrderTypeConfiguration : IEntityTypeConfiguration<BookingTableOrder>
	{
		public void Configure(EntityTypeBuilder<BookingTableOrder> builder)
		{
			builder.Property(x => x.ClientName).IsRequired();
			builder.Property(x => x.TableNumber).IsRequired();
			builder.Property(x => x.ReservedPeopleAmount).IsRequired().HasMaxLength(10);
		}
	}
}