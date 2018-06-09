using System.Collections.Generic;
using Solution.Model.Enums;

namespace Solution.Model.Models
{
	public class AuthenticatedModel
	{
		public string Jwt { get; set; }

		public IEnumerable<Roles> Roles { get; set; } = new List<Roles>();

		public long UserId { get; set; }
	}
}
