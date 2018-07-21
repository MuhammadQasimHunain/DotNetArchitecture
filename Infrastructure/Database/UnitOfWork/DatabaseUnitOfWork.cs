namespace Solution.Infrastructure.Database
{
	public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
	{
		public DatabaseUnitOfWork(
			IUserRepository user,
			IUserLogRepository userLog,
			DatabaseContext context)
		{
			User = user;
			UserLog = userLog;
			Context = context;
		}

		public IUserRepository User { get; }

		public IUserLogRepository UserLog { get; }

		private DatabaseContext Context { get; set; }

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
