using ChuckSwapi.Api.Application.Models;
using ChuckSwapi.Api.Application.Services.Interfaces;
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