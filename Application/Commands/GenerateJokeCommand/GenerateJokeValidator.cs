using FluentValidation;

namespace ChuckSwapi.Api.Application.Commands.GenerateJokeCommand;

public class GenerateJokeValidator : AbstractValidator<GenerateJokeCommand>
{
	public GenerateJokeValidator()
	{
		RuleFor(x => x.Category).NotEmpty();
	}
}