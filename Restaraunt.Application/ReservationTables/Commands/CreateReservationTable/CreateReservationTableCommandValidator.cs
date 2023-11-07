using FluentValidation;
using Restaraunt.Application.ReservationTables.Commands;

namespace Restaraunt.Application.Reservation_Tables.Commands
{
	public class CreateReservationTableCommandValidator : AbstractValidator<CreateReservationTableCommand>
	{
		public CreateReservationTableCommandValidator()
		{
			RuleFor(createCommand => createCommand.Number).GreaterThan(0);
		}
	}
}
