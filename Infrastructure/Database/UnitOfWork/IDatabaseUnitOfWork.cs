namespace Solution.Infrastructure.Database
{
	public interface IDatabaseUnitOfWork
	{
		IUserRepository User { get; }
		IUserLogRepository UserLog { get; }
		IUserRoleRepository UserRole { get; }

		void SaveChanges();
	}
}
