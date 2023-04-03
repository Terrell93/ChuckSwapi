using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapi.Api.Infrastructure;

public class ResponseHandler : IResponseHandler
{
	public IActionResult Handle(bool success, string message)
	{
		if (success)
		{
			return new OkObjectResult(new { message });
		}

		return new BadRequestObjectResult(new { message });
	}
}