using Solution.Infrastructure.EntityFrameworkCore;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
	public sealed class UserLogRepository : EntityFrameworkCoreRepository<UserLogModel>, IUserLogRepository
	{
		public UserLogRepository(DatabaseContext context) : base(context)
		{
		}
	}
}
