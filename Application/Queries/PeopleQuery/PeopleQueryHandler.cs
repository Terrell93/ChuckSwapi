using ChuckSwapi.Api.Application.Models;
using MediatR;
using Newtonsoft.Json;

namespace ChuckSwapi.Api.Application.Queries.PeopleQuery;

public class PeopleQueryHandler : IRequestHandler<PeopleQuery, List<StarWarsCharacter>>
{
	public Task<List<StarWarsCharacter>> Handle(PeopleQuery request, CancellationToken cancellationToken)
	{
		var person = GetPerson();
		return person;
	}

	private async Task<List<StarWarsCharacter>> GetPerson()
	{
		var peopleList = new List<StarWarsCharacter>();
		const string url = $"https://swapi.dev/api/people/";
		var client = new HttpClient();
		using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
		response.EnsureSuccessStatusCode();

		if (!response.IsSuccessStatusCode) return await Task.FromResult(peopleList);

		if (response.Content != null)
		{
			var contentStream = await response.Content.ReadAsStreamAsync();

			using var streamReader = new StreamReader(contentStream);
			await using var jsonReader = new JsonTextReader(streamReader);

			var serializer = new JsonSerializer();

			try
			{
				var peopleResponse = serializer.Deserialize<PeopleResponse>(jsonReader);

				foreach (var person in peopleResponse.Results)
				{
					peopleList.Add(person);
				}
				
				/*peopleList.Add(person);*/
			}
			catch(Exception e)
			{
				throw new Exception("",e);
			} 
		}

		return await Task.FromResult(peopleList);
	}
}