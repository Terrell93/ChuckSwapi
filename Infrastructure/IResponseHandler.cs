using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapi.Api.Infrastructure;

public interface IResponseHandler
{
	public IActionResult Handle(bool success, string message);
}