using FluentValidation;

namespace Restaraunt.Application.Reservation_Tables.Commands.UpdateReservationTable
{
	public class UpdateReservationTableCommandValidator : AbstractValidator<UpdateReservationTableCommand>
	{
		public UpdateReservationTableCommandValidator()
		{
			RuleFor(updateCommand => updateCommand.Id).NotEmpty();
			RuleFor(updateCommand => updateCommand.Number).GreaterThan(0).NotEmpty();
		}
	}
}