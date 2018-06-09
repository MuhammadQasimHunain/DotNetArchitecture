using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.CrossCutting.Utils;
using Solution.Model.Enums;
using Solution.Model.Models;
using Solution.Web.UserInterface.Attributes;

namespace Solution.Web.UserInterface.Controllers
{
	[Route("[controller]")]
	public class AuthenticationServiceController : BaseController
	{
		public AuthenticationServiceController(IAuthenticationApplication authentication)
		{
			Authentication = authentication;
		}

		IAuthenticationApplication Authentication { get; }

		[AllowAnonymous]
		[HttpPost("[action]")]
		public IActionResult Authenticate([FromBody]AuthenticationModel authentication)
		{
			return Json(Authentication.AuthenticateCreateJwt(authentication));
		}

		[HttpPost("[action]")]
		public void Logout()
		{
			Authentication.Logout(User.GetAuthenticatedUserId());
		}
	}
}
