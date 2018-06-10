using System.Linq;
using Solution.CrossCutting.Mapping;
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

		IDatabaseUnitOfWork Database { get; }
		IHash Hash { get; }
		IJsonWebToken JsonWebToken { get; }
		IUserLogDomain UserLog { get; }

		public string Authenticate(AuthenticationModel authentication)
		{
			new AuthenticationValidation().ValidateThrowException(authentication);

			SetHash(authentication);

			var authenticated = Database.User.Authenticate(authentication);

			new AuthenticatedValidation().ValidateThrowException(authenticated);

			UserLog.Save(authenticated.UserId, LogType.Login);

			return GetJwt(authenticated);
		}

		public void Logout(long userId)
		{
			UserLog.Save(userId, LogType.Logout);
		}

		private string GetJwt(AuthenticatedModel authenticated)
		{
			var roles = authenticated.Roles.Select(role => role.ToString()).ToArray();
			return JsonWebToken.Encode(authenticated.UserId.ToString(), roles);
		}

		private void SetHash(AuthenticationModel authentication)
		{
			authentication.Login = Hash.Create(authentication.Login);
			authentication.Password = Hash.Create(authentication.Password);
		}
	}
}
