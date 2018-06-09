using Solution.CrossCutting.Utils;
using Solution.Infrastructure.Database;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
	public sealed class UserDomain : BaseDomain, IUserDomain
	{
		public UserDomain(IDatabaseUnitOfWork database)
		{
			Database = database;
		}

		IDatabaseUnitOfWork Database { get; }

		public PagedList<UserModel> List(PagedListParameters parameters)
		{
			return Database.User.List(parameters);
		}

		public UserModel Select(long userId)
		{
			return Database.User.Select(userId);
		}
	}
}
