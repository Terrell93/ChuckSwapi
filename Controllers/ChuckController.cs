using ChuckSwapi.Api.Application.Commands.GenerateJokeCommand;
using ChuckSwapi.Api.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ChuckController : ControllerBase
{
	private readonly IChuckNorrisService _chuckNorrisService;

	public ChuckController(IMediator mediator, IChuckNorrisService chuckNorrisService)
	{
		_chuckNorrisService = chuckNorrisService ?? throw new ArgumentNullException(nameof(chuckNorrisService));
	}

	[HttpGet("Categories")]
	public Task<ActionResult> Search()
	{
		var categories = _chuckNorrisService.GetCategories();
		return Task.FromResult<ActionResult>(Ok(categories));
	}
	
	[HttpGet("GetJoke")]
	public Task<ActionResult> GetJoke([FromQuery]GenerateJokeCommand command)
	{
		var categories = _chuckNorrisService.GetJokes(command);
		return Task.FromResult<ActionResult>(Ok(categories));
	}

}