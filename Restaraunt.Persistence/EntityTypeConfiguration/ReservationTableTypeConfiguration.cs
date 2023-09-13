using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Persistence.EntityTypeConfiguration
{
	public class ReservationTableTypeConfiguration : IEntityTypeConfiguration<ReservationTable>
	{
		public void Configure(EntityTypeBuilder<ReservationTable> builder)
		{
			builder.HasIndex(x => x.Number).IsUnique();
			builder.Property(x => x.IsReserved).IsRequired();


			builder.HasOne(x => x.BookingTableOrder)
				.WithOne(x => x.ReservationTable)
				.HasForeignKey<BookingTableOrder>(x => x.ReservationTableId);

			for (var i = 1; i < 7; i++)
				builder.HasData(new ReservationTable
				{
					Id = i,
					Number = i,
					IsReserved = false,
				});
		}
	}
}
