using Solution.Model.Models;

namespace Solution.Application.Applications
{
	public interface IAuthenticationApplication : IBaseApplication
	{
		AuthenticatedModel Authenticate(AuthenticationModel authentication);

		string AuthenticateCreateJwt(AuthenticationModel authentication);

		string CreateJwt(AuthenticatedModel authenticated);

		void Logout(long userId);
	}
}
