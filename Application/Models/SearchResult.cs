namespace ChuckSwapi.Api.Application.Models;

public class SearchResult
{
	public string Api { get; set; }
	public StarWarsSearchResult? StarWarsSearchResult { get; set; }
	public ChuckNorrisSearchResult? ChuckNorrisSearchResult { get; set; }
}