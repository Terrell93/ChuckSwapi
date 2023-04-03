using ChuckSwapi.Api.Application.Models;
using ChuckSwapi.Api.Application.Queries.SearchQuery;
using ChuckSwapi.Api.Application.Services.Interfaces;
using MediatR;

namespace ChuckSwapi.Api.Application.Services;

public class SearchService : ISearchService
{
	private readonly IMediator _mediator;

	public SearchService(IMediator mediator)
	{
		_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
	}

	public Task<List<SearchResult>> ReturnSearch(string jokeQuery, string peopleQuery)
	{
		var query = new SearchQuery()
		{
			PeopleQuery = peopleQuery,
			JokeQuery = jokeQuery
		};
		
		var search = _mediator.Send(query);
		return search;
	}
}