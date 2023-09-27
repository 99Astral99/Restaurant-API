using MediatR;

namespace Restaraunt.Application.Reservation_Tables.Commands.UpdateReservationTable
{
	public sealed record UpdateReservationTableCommand
		(int Id,
		int Number,
		bool IsReserved)
		:IRequest<Unit>;
}
