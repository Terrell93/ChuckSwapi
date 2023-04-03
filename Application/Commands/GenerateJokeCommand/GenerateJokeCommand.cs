using ChuckSwapi.Api.Application.Models;
using MediatR;

namespace ChuckSwapi.Api.Application.Commands.GenerateJokeCommand;

public class GenerateJokeCommand : IRequest<Joke>
{
	public string Category { get; set; }
}