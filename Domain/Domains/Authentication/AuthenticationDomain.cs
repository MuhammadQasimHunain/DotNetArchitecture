using System.Linq;
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

		public AuthenticatedModel Authenticate(AuthenticationModel authentication)
		{
			new AuthenticationValidation().ValidateThrowException(authentication);

			authentication.Login = Hash.Create(authentication.Login);
			authentication.Password = Hash.Create(authentication.Password);

			var authenticated = Database.User.Authenticate(authentication);

			new AuthenticatedValidation().ValidateThrowException(authenticated);

			var userLog = UserLog.Create(authenticated.UserId, LogType.Login);
			UserLog.AddSaveChanges(userLog);

			return authenticated;
		}

		public string AuthenticateCreateJwt(AuthenticationModel authentication)
		{
			return CreateJwt(Authenticate(authentication));
		}

		public string CreateJwt(AuthenticatedModel authenticated)
		{
			var roles = authenticated.Roles.Select(role => role.ToString()).ToArray();
			return JsonWebToken.Encode(authenticated.UserId.ToString(), roles);
		}

		public void Logout(long userId)
		{
			var userLog = UserLog.Create(userId, LogType.Logout);
			UserLog.AddSaveChanges(userLog);
		}
	}
}
