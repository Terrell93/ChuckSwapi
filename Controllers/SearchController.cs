using ChuckSwapi.Api.Application.Commands.GenerateJokeCommand;
using ChuckSwapi.Api.Application.Queries.CategoriesQuery;
using ChuckSwapi.Api.Application.Queries.SearchQuery;
using ChuckSwapi.Api.Application.Services.Interfaces;
using ChuckSwapi.Api.Data;
using ChuckSwapi.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
	private readonly ISearchService _searchService;

	public SearchController(ISearchService searchService)
	{
		_searchService = searchService ?? throw new ArgumentNullException(nameof(searchService));
	}
	
	[HttpGet()]
	public Task<ActionResult> Search([FromQuery] Search query)
	{
		var search = _searchService.ReturnSearch(query.JokeQuery, query.PeopleQuery);

		return Task.FromResult<ActionResult>(Ok(search));
	}
}