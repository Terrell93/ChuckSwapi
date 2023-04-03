using ChuckSwapi.Api.Infrastructure;
using MediatR;
using Newtonsoft.Json;

namespace ChuckSwapi.Api.Application.Queries.CategoriesQuery;

public class CategoriesQueryHandler : IRequestHandler<CategoriesQuery, List<string>>
{
	public Task<List<string>> Handle(CategoriesQuery request, CancellationToken cancellationToken)
	{
		var categories = GetCategories();

		return Task.FromResult(categories.Result);
	}
	
	private async Task<List<string>> GetCategories()
	{
		var categoriesData = new List<string>();
		const string url = $"https://api.chucknorris.io/jokes/categories";
		var client = new HttpClient();
		using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
		response.EnsureSuccessStatusCode();

		if (!response.IsSuccessStatusCode) return categoriesData;
		
		if (response.Content != null)
		{
			var contentStream = await response.Content.ReadAsStreamAsync();

			using var streamReader = new StreamReader(contentStream);
			using var jsonReader = new JsonTextReader(streamReader);

			JsonSerializer serializer = new JsonSerializer();

			try
			{
				var categories = serializer.Deserialize<List<string>>(jsonReader);
				categoriesData.AddRange(categories);
			}
			catch(Exception e)
			{
				throw new Exception("",e);
			} 
		}

		return await Task.FromResult(categoriesData);
	}
}