using MediatR;

namespace Restaraunt.Application.Reservation_Tables.Queries
{
	public sealed record GetUnreservedTableListQuery : IRequest<ReservationTableListVm>;
}
