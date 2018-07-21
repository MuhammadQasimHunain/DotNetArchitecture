using Solution.CrossCutting.Security;
using Solution.Infrastructure.Database;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
	public sealed class AuthenticationDomain : BaseDomain, IAuthenticationDomain
	{
		public AuthenticationDomain(
			IDatabaseUnitOfWork database,
			IHash hash,
			IJsonWebToken jsonWebToken,
			IUserLogDomain userLog)
		{
			Database = database;
			Hash = hash;
			JsonWebToken = jsonWebToken;
			UserLog = userLog;
		}

		private IDatabaseUnitOfWork Database { get; }
		private IHash Hash { get; }
		private IJsonWebToken JsonWebToken { get; }
		private IUserLogDomain UserLog { get; }

		public string Authenticate(AuthenticationModel authentication)
		{
			new AuthenticationValidator().ValidateThrowException(authentication);

			SetHash(authentication);

			var authenticated = Database.User.Authenticate(authentication);

			new AuthenticatedValidator().ValidateThrowException(authenticated);

			UserLog.Save(authenticated.UserId, LogType.Login);

			return GetJwt(authenticated);
		}

		public void Logout(long userId)
		{
			UserLog.Save(userId, LogType.Logout);
		}

		private string GetJwt(AuthenticatedModel authenticated)
		{
			var roles = authenticated.Roles.ToString().Split(", ");
			return JsonWebToken.Encode(authenticated.UserId.ToString(), roles);
		}

		private void SetHash(AuthenticationModel authentication)
		{
			authentication.Login = Hash.Create(authentication.Login);
			authentication.Password = Hash.Create(authentication.Password);
		}
	}
}
