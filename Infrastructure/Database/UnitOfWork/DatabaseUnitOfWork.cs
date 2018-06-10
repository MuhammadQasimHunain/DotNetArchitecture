namespace Solution.Infrastructure.Database
{
	public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
	{
		public DatabaseUnitOfWork(
			IUserRepository user,
			IUserLogRepository userLog,
			IUserRoleRepository userRole,
			DatabaseContext context)
		{
			User = user;
			UserLog = userLog;
			UserRole = userRole;
			Context = context;
		}

		public IUserRepository User { get; }
		public IUserLogRepository UserLog { get; }
		public IUserRoleRepository UserRole { get; }

		DatabaseContext Context { get; set; }

		public void DiscardChanges()
		{
			if (Context != null)
			{
				Context.Dispose();
				Context = null;
			}
		}

		public void SaveChanges()
		{
			Context.SaveChanges();
		}
	}
}
