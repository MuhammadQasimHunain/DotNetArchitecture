namespace Solution.Infrastructure.Database
{
	public interface IDatabaseUnitOfWork
	{
		IUserRepository User { get; }

		IUserLogRepository UserLog { get; }

		void SaveChanges();
	}
}
