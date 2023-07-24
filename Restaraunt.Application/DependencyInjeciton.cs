using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Restaraunt.Application.Common.Behaviors;
using System.Reflection;

namespace Restaraunt.Application
{
	public static class DependencyInjeciton
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(cfg =>
			cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
			services.AddTransient(typeof(IPipelineBehavior<,>),
				typeof(ValidationBehavior<,>));
			return services;
		}
	}
}
