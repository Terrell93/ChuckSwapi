using ChuckSwapi.Api.Application.Models;
using ChuckSwapi.Api.Application.Queries.PeopleQuery;
using ChuckSwapi.Api.Application.Services.Interfaces;
using MediatR;

namespace ChuckSwapi.Api.Application.Services;

public class StarWarsService : IStarWarsService
{
	private readonly IMediator _mediator;

	public StarWarsService(IMediator mediator)
	{
		_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
	}

	public List<StarWarsCharacter> GetPeople()
	{
		var people = _mediator.Send(new PeopleQuery());
		return people.Result;
	}

	public void Search()
	{
		throw new NotImplementedException();
	}
}