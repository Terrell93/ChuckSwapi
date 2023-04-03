using ChuckSwapi.Api.Application.Models;
using MediatR;
using Newtonsoft.Json;

namespace ChuckSwapi.Api.Application.Queries.SearchQuery;

public class SearchQueryHandler : IRequestHandler<SearchQuery, SearchDto>
{
	public async Task<SearchDto> Handle(SearchQuery request, CancellationToken cancellationToken)
	{
		var jokeUrl = $"https://api.chucknorris.io/jokes/search?query={request.JokeQuery}";
		var peopleUrl = $"https://swapi.dev/api/people/?search={request.PeopleQuery}";

		var jokeResponse = await GetResponse(jokeUrl);
		var jokes = GetJokes(jokeResponse);

		var peopleResponse = await GetResponse(peopleUrl);
		var people = GetPeople(peopleResponse);

		var search = new SearchDto()
		{
			Joke = jokes.Result,
			People = people.Result
		};

		return search;
	}

	private async Task<HttpResponseMessage> GetResponse(string url)
	{
		var client = new HttpClient();
		using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
		response.EnsureSuccessStatusCode();

		return response;
	}

	private static async Task<List<PeopleDto>> GetPeople(HttpResponseMessage response)
	{
		var peopleList = new List<PeopleDto>();
		
		var contentStream = await response.Content.ReadAsStreamAsync();

		using var streamReader = new StreamReader(contentStream);
		await using var jsonReader = new JsonTextReader(streamReader);

		var serializer = new JsonSerializer();

		try
		{
			var person = serializer.Deserialize<PeopleDto>(jsonReader);
			if (person != null) peopleList.Add(person);
		}
		catch (Exception e)
		{
			throw new Exception("", e);
		}

		return peopleList;
	}

	private static async Task<JokeSearch?> GetJokes(HttpResponseMessage response)
	{
		var contentStream = await response.Content.ReadAsStreamAsync();

		using var streamReader = new StreamReader(contentStream);
		await using var jsonReader = new JsonTextReader(streamReader);

		var serializer = new JsonSerializer();

		try
		{
			var jokes = serializer.Deserialize<JokeSearch>(jsonReader);
			return jokes;
		}
		catch (Exception e)
		{
			throw new Exception("", e);
		}
	}
}