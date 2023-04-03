using ChuckSwapi.Api.Application.Models;
using MediatR;

namespace ChuckSwapi.Api.Application.Queries.SearchQuery;

public class SearchQuery : IRequest<SearchDto>
{
	public string JokeQuery { get; set; }
	public string PeopleQuery { get; set; }
}