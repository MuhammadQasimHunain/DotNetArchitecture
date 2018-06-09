using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Solution.Model.Enums;

namespace Solution.Web.UserInterface.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public sealed class AuthorizationAttribute : AuthorizeAttribute
	{
		public AuthorizationAttribute(params Roles[] roles)
		{
			Roles = string.Join(", ", roles.Select(role => Enum.GetName(role.GetType(), role)));
		}
	}
}
