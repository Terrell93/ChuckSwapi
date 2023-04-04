using ChuckSwapi.Api.Application.Commands.GenerateJokeCommand;
using ChuckSwapi.Api.Application.Models;

namespace ChuckSwapi.Api.Application.Services.Interfaces;

public interface IChuckNorrisService
{
	public Joke GetJokes(GenerateJokeCommand command);
	public List<string> GetCategories();
}