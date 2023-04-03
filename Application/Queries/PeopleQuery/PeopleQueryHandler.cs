using ChuckSwapi.Api.Application.Models;
using MediatR;
using Newtonsoft.Json;

namespace ChuckSwapi.Api.Application.Queries.PeopleQuery;

public class PeopleQueryHandler : IRequestHandler<PeopleQuery, List<PeopleDto>>
{
	public Task<List<PeopleDto>> Handle(PeopleQuery request, CancellationToken cancellationToken)
	{
		var person = GetPerson();
		return person;
	}

	private async Task<List<PeopleDto>> GetPerson()
	{
		var peopleList = new List<PeopleDto>();
		const string url = $"https://swapi.dev/api/people/";
		var client = new HttpClient();
		using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
		response.EnsureSuccessStatusCode();

		if (!response.IsSuccessStatusCode) return await Task.FromResult(peopleList);

		if (response.Content != null)
		{
			var contentStream = await response.Content.ReadAsStreamAsync();

			using var streamReader = new StreamReader(contentStream);
			using var jsonReader = new JsonTextReader(streamReader);

			JsonSerializer serializer = new JsonSerializer();

			try
			{
				var person = serializer.Deserialize<PeopleDto>(jsonReader);
				peopleList.Add(person);
			}
			catch(Exception e)
			{
				throw new Exception("",e);
			} 
		}

		return await Task.FromResult(peopleList);
	}
}