using MediatR;

namespace Restaraunt.Application.Reservation_Tables.Queries
{
	public sealed record GetReservationTableListQuery : IRequest<ReservationTableListVm>;
}
