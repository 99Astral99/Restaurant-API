using MediatR;
using Restaraunt.Application.Reservation_Tables.Queries;

namespace Restaraunt.Application.ReservationTables.Queries.GetReservedTableList
{
	public sealed record GetReservedTableListQuery : IRequest<ReservationTableListVm>;
}
