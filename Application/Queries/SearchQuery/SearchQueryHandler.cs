using ChuckSwapi.Api.Application.Models;
using MediatR;
using Newtonsoft.Json;

namespace ChuckSwapi.Api.Application.Queries.SearchQuery;

public class SearchQueryHandler : IRequestHandler<SearchQuery, List<SearchResult>>
{
	public Task<List<SearchResult>> Handle(SearchQuery request, CancellationToken cancellationToken)
	{
		var response = GetResponse(request);
		var searchResults = ProcessResults(response.Result);

		return Task.FromResult(searchResults.Result);
	}

	private async Task<HttpResponseMessage[]> GetResponse(SearchQuery request)
	{
		var client = new HttpClient();
		
		var jokeUrl = $"https://api.chucknorris.io/jokes/search?query={request.JokeQuery}";
		var peopleUrl = $"https://swapi.dev/api/people/?search={request.PeopleQuery}";
		
		var chuckNorrisTask = client.GetAsync(jokeUrl);
		var starWarsTask = client.GetAsync(peopleUrl);
		var responses = await Task.WhenAll(chuckNorrisTask, starWarsTask);
		
		return responses;
	}

	private static async Task<List<SearchResult>> ProcessResults(IEnumerable<HttpResponseMessage> responses)
	{
		var results = new List<SearchResult>();
		foreach (var response in responses) {
			if (response.RequestMessage.RequestUri.ToString().Contains("chucknorris")) {
				var content = await response.Content.ReadAsStringAsync();
				dynamic? data = JsonConvert.DeserializeObject<ChuckNorrisSearchResult>(content);
				results.Add(new SearchResult { Api = "Chuck Norris", ChuckNorrisSearchResult = data });
			}
			else if (response.RequestMessage.RequestUri.ToString().Contains("swapi")) {
				var content = await response.Content.ReadAsStringAsync();
				dynamic? data = JsonConvert.DeserializeObject<StarWarsSearchResult>(content);
				results.Add(new SearchResult { Api = "Star Wars", StarWarsSearchResult = data });
			}
		}

		return results;
	}
}