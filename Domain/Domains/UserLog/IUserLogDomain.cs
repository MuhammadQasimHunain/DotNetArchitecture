using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
	public interface IUserLogDomain : IBaseDomain
	{
		void Save(long userId, LogType logType);
	}
}
