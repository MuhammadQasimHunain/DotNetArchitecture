using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Model.Models;

namespace Solution.Web.UserInterface.Controllers
{
	[Route("[controller]")]
	public class ApplicationServiceController : BaseController
	{
		[AllowAnonymous]
		[HttpGet]
		[ResponseCache(Duration = 1440)]
		public IActionResult Get()
		{
			return Json(new ApplicationModel());
		}
	}
}
