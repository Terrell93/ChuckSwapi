using ChuckSwapi.Api.Application.Models;
using MediatR;
using Newtonsoft.Json;

namespace ChuckSwapi.Api.Application.Commands.GenerateJokeCommand;

public class GenerateJokeCommandHandler : IRequestHandler<GenerateJokeCommand, JokeDto>
{
	public Task<JokeDto> Handle(GenerateJokeCommand request, CancellationToken cancellationToken)
	{
		var jokes = Getjokes(request.Category);

		return Task.FromResult(jokes.Result);
	}

	private async Task<JokeDto> Getjokes(string category)
	{
		var jokesData = new JokeDto();
		var url = $"https://api.chucknorris.io/jokes/random?category={category}";
		var client = new HttpClient();
		using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
		response.EnsureSuccessStatusCode();
		
		if (!response.IsSuccessStatusCode) return jokesData;
		
		if (response.Content != null)
		{
			var contentStream = await response.Content.ReadAsStreamAsync();

			using var streamReader = new StreamReader(contentStream);
			using var jsonReader = new JsonTextReader(streamReader);

			JsonSerializer serializer = new JsonSerializer();

			try
			{
				var categories = serializer.Deserialize<JokeDto>(jsonReader);
				jokesData = categories;
			}
			catch(Exception e)
			{
				throw new Exception("",e);
			} 
		}
		
		return await Task.FromResult(jokesData);
	}
}