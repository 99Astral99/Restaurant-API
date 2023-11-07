using FluentValidation;

namespace Restaraunt.Application.Reservation_Tables.Commands.DeleteReservationTable
{
	public class DeleteReservationTableCommandValidator : AbstractValidator<DeleteReservationTableCommand>
	{
		public DeleteReservationTableCommandValidator()
		{
			RuleFor(deleteCommand =>
				deleteCommand.Id).NotEmpty();
		}
	}
}
