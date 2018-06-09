using Solution.Model.Enums;

namespace Solution.Model.Models
{
	public class UserRoleModel
	{
		public Roles Role { get; set; }

		public virtual UserModel User { get; set; }

		public long UserId { get; set; }
	}
}
