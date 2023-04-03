namespace ChuckSwapi.Api.Application.Models;

public class StarWarsSearchResult
{
	public int Count { get; set; }
	public List<StarWarsCharacter> Results { get; set; }
}