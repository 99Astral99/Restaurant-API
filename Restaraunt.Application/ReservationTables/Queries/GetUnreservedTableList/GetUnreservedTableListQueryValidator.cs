using FluentValidation;
using Restaraunt.Application.Reservation_Tables.Queries;

namespace Restaraunt.Application.ReservationTables.Queries.GetUnreservedTableList
{
	public class GetUnreservedTableListQueryValidator:AbstractValidator<GetUnreservedTableListQuery>
	{
        public GetUnreservedTableListQueryValidator()
        {
            //empty
        }
    }
}
