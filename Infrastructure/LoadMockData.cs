using ChuckSwapi.Api.Data.Entities;

namespace ChuckSwapi.Api.Infrastructure;

public class LoadMockData : ILoadMockData
{
	public void LoadData()
	{
		throw new NotImplementedException();
	}

	public void LoadPeopleData()
	{
		throw new NotImplementedException();
	}

	public Categories LoadCategoryData()
	{
		var categoryData = new List<string>
		{
			"animal", "career", "celebrity", "dev", "explicit", "fashion", "food", "history", "money", "movie", "music",
			"political", "religion", "science", "sport", "travel"
		};
		return new Categories
		{
			CategoryList = categoryData
		};
	}
}