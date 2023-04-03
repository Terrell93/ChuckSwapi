using ChuckSwapi.Api.Application.Models;

namespace ChuckSwapi.Api.Application.Services.Interfaces;

public interface ISearchService
{
	public Task<List<SearchResult>> ReturnSearch(string jokeQuery, string peopleQuery);
}