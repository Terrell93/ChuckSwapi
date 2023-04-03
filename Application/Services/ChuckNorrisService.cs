using ChuckSwapi.Api.Application.Commands.GenerateJokeCommand;
using ChuckSwapi.Api.Application.Models;
using ChuckSwapi.Api.Application.Queries.CategoriesQuery;
using ChuckSwapi.Api.Application.Services.Interfaces;
using ChuckSwapi.Api.Data.Entities;
using MediatR;

namespace ChuckSwapi.Api.Application.Services;

public class ChuckNorrisService : IChuckNorrisService
{
	private readonly IMediator _mediator;

	public ChuckNorrisService(IMediator mediator)
	{
		_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
	}

	public JokeDto GetJokes(GenerateJokeCommand command)
	{
		var joke = _mediator.Send(command);
		return joke.Result;
	}

	public List<string> GetCategories()
	{
		var categories = _mediator.Send(new CategoriesQuery());
		return categories.Result;
	}

	public void Search()
	{
		throw new NotImplementedException();
	}
}