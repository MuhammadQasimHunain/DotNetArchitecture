using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.CrossCutting.Utils;
using Solution.Model.Enums;
using Solution.Model.Models;
using Solution.Web.UserInterface.Attributes;

namespace Solution.Web.UserInterface.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthenticationServiceController : ControllerBase
	{
		public AuthenticationServiceController(IAuthenticationApplication authentication)
		{
			Authentication = authentication;
		}

		private IAuthenticationApplication Authentication { get; }

		[AllowAnonymous]
		[HttpPost("[action]")]
		public string Authenticate(AuthenticationModel authentication)
		{
			return Authentication.Authenticate(authentication);
		}

		[HttpPost("[action]")]
		public void Logout()
		{
			Authentication.Logout(User.GetAuthenticatedUserId());
		}
	}
}
