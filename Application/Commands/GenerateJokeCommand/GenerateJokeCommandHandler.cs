using ChuckSwapi.Api.Application.Models;
using MediatR;
using Newtonsoft.Json;

namespace ChuckSwapi.Api.Application.Commands.GenerateJokeCommand;

public class GenerateJokeCommandHandler : IRequestHandler<GenerateJokeCommand, Joke>
{
	public Task<Joke> Handle(GenerateJokeCommand request, CancellationToken cancellationToken)
	{
		var jokes = Getjokes(request.Category);

		return Task.FromResult(jokes.Result);
	}

	private async Task<Joke> Getjokes(string category)
	{
		var jokesData = new Joke();
		var url = $"https://api.chucknorris.io/jokes/random?category={category}";
		var client = new HttpClient();
		using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
		response.EnsureSuccessStatusCode();
		
		if (!response.IsSuccessStatusCode) return jokesData;

		if (response.Content == null) return await Task.FromResult(jokesData);
		var contentStream = await response.Content.ReadAsStreamAsync();

		using var streamReader = new StreamReader(contentStream);
		await using var jsonReader = new JsonTextReader(streamReader);

		var serializer = new JsonSerializer();

		try
		{
			var categories = serializer.Deserialize<Joke>(jsonReader);
			jokesData = categories;
		}
		catch(Exception e)
		{
			throw new Exception("Could not load jokes",e);
		}

		return await Task.FromResult(jokesData);
	}
}