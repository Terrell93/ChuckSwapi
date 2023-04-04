using FluentValidation;

namespace ChuckSwapi.Api.Application.Queries.SearchQuery;

public class SearchQueryValidator : AbstractValidator<SearchQuery>
{
	public SearchQueryValidator()
	{
		RuleFor(x => x.PeopleQuery).NotEmpty();
		RuleFor(x => x.JokeQuery).NotEmpty();
	}
}