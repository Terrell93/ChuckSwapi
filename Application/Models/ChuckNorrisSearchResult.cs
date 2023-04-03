namespace ChuckSwapi.Api.Application.Models;

public class ChuckNorrisSearchResult
{
	public int Total { get; set; }
	public List<ChuckNorrisJoke> Result { get; set; }
}