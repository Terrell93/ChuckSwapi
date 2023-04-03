namespace ChuckSwapi.Api.Application.Models;

public class PeopleResponse
{
	public int Count { get; set; }
	public string Next { get; set; }
	public string Previous { get; set; }
	public StarWarsCharacter[] Results { get; set; }
}