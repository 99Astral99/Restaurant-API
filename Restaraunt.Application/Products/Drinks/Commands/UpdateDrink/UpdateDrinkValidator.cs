﻿using FluentValidation;

namespace Restaraunt.Application.Products.Drinks.Commands.UpdateDrink
{
	public class UpdateDrinkValidator : AbstractValidator<UpdateDrinkCommand>
	{
		public UpdateDrinkValidator()
		{
			RuleFor(createdrinkCommand =>
				createdrinkCommand.Name).NotEmpty().MaximumLength(50);

			RuleFor(createdrinkCommand =>
				createdrinkCommand.Price).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(1500);

			RuleFor(createdrinkCommand =>
				createdrinkCommand.Description).NotEmpty().MaximumLength(700);

			RuleFor(createdrinkCommand =>
				createdrinkCommand.Size).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(2000);

			RuleFor(createdrinkCommand =>
				createdrinkCommand.IsCarbonated).NotEmpty();
		}
	}
}
