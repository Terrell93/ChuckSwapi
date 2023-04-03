namespace ChuckSwapi.Api.Application.Models;

public class SearchDto
{
	public JokeSearch? Joke { get; set; }
	public List<StarWarsCharacter> People { get; set; }
}