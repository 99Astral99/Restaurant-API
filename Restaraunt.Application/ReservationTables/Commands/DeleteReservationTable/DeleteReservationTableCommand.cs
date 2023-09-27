using MediatR;

namespace Restaraunt.Application.Reservation_Tables.Commands.DeleteReservationTable
{
	public sealed record DeleteReservationTableCommand(int Id) : IRequest<Unit>;
}
