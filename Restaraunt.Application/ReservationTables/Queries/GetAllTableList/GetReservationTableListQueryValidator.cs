using FluentValidation;
using Restaraunt.Application.Reservation_Tables.Queries;

namespace Restaraunt.Application.ReservationTables.Queries.GetAllTableList
{
	public class GetReservationTableListQueryValidator : AbstractValidator<GetReservationTableListQuery>
	{
		public GetReservationTableListQueryValidator()
		{
			//empty
		}
	}
}
