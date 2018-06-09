using Solution.CrossCutting.Utils;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
	public interface IUserRepository : IRepository<UserModel>
	{
		AuthenticatedModel Authenticate(AuthenticationModel authentication);
	}
}
