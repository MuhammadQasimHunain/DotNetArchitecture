using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.Model.Models;

namespace Solution.Api.Authentication
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		public AuthenticationController(IAuthenticationApplication authentication)
		{
			Authentication = authentication;
		}

		private IAuthenticationApplication Authentication { get; }

		[AllowAnonymous]
		[HttpGet]
		public string Get()
		{
			return nameof(AuthenticationController);
		}

		[AllowAnonymous]
		[HttpPost]
		public string Post([FromBody] AuthenticationModel authentication)
		{
			return Authentication.Authenticate(authentication);
		}
	}
}
