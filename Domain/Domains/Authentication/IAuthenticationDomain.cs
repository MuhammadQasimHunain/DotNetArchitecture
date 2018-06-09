using Solution.Model.Models;

namespace Solution.Domain.Domains
{
	public interface IAuthenticationDomain : IBaseDomain
	{
		AuthenticatedModel Authenticate(AuthenticationModel authentication);

		void Logout(long userId);
	}
}
