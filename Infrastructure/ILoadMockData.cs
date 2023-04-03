using ChuckSwapi.Api.Data.Entities;

namespace ChuckSwapi.Api.Infrastructure;

public interface ILoadMockData
{
	public void LoadData();
	public void LoadPeopleData();
	public Categories LoadCategoryData();
}