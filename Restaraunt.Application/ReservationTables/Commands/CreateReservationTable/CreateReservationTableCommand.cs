using MediatR;

namespace Restaraunt.Application.ReservationTables.Commands
{
	public sealed record CreateReservationTableCommand
		(
		int Number
		) : IRequest<int>;
}
