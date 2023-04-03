using ChuckSwapi.Api.Application.Queries.PeopleQuery;
using ChuckSwapi.Api.Application.Queries.SearchQuery;
using ChuckSwapi.Api.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StarWarsController : ControllerBase
{
	private readonly IStarWarsService _starWarsService;

	public StarWarsController(IStarWarsService starWarsService)
	{
		_starWarsService = starWarsService ?? throw new ArgumentNullException(nameof(starWarsService));
	}

	// people
	// search
	[HttpGet("People")]
	public Task<ActionResult> GetPeople()
	{
		var people = _starWarsService.GetPeople();
		return Task.FromResult<ActionResult>(Ok(people));
	}
}