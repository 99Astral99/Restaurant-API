using FluentValidation;

namespace Restaraunt.Application.ReservationTables.Queries.GetReservedTableList
{
	public class GetReservedTableListQueryValidator:AbstractValidator<GetReservedTableListQuery>
	{
        public GetReservedTableListQueryValidator()
        {
            //empty
        }
    }
}
