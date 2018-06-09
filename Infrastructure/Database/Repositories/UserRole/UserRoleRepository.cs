using Solution.Infrastructure.EntityFrameworkCore;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
	public sealed class UserRoleRepository : EntityFrameworkCoreRepository<UserRoleModel>, IUserRoleRepository
	{
		public UserRoleRepository(DatabaseContext context) : base(context)
		{
		}
	}
}
