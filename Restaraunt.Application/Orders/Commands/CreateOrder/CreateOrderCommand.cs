using MediatR;
using System.Text.Json.Serialization;

namespace Restaraunt.Application.Orders.Commands
{
	public class CreateOrderCommand : IRequest<int>
	{
		public Guid ProductId { get; set; }
		public int Count { get; set; }

		[JsonIgnore]
		public string UserName { get; set; } = string.Empty;
	}
}
