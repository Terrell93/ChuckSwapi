using ChuckSwapi.Api.Application.Models;

namespace ChuckSwapi.Api.Application.Services.Interfaces;

public interface IStarWarsService
{
	public List<StarWarsCharacter> GetPeople();
}