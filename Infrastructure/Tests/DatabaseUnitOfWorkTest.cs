using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Utils;
using Solution.Infrastructure.Database;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Tests
{
	[TestClass]
	public class DatabaseUnitOfWorkTest
	{
		public DatabaseUnitOfWorkTest()
		{
			DependencyInjector.RegisterServices();
			DependencyInjector.AddDbContextInMemoryDatabase<DatabaseContext>();
			Database = DependencyInjector.GetService<IDatabaseUnitOfWork>();
			SeedDatabase();
		}

		private IDatabaseUnitOfWork Database { get; }

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryAny()
		{
			var result = Database.User.Any();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryAnyAsynchronous()
		{
			var result = Database.User.AnyAsync();
			Assert.IsTrue(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryAnyWhere()
		{
			var result = Database.User.Any(w => w.UserId == 1);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryAnyWhereAsynchronous()
		{
			var result = Database.User.AnyAsync(w => w.UserId == 1);
			Assert.IsTrue(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryCount()
		{
			var result = Database.User.Count();
			Assert.IsTrue(result > 0);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryCountAsynchronous()
		{
			var result = Database.User.CountAsync();
			Assert.IsTrue(result.Result > 0);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryCountWhere()
		{
			var result = Database.User.Count(w => w.UserId == 1);
			Assert.IsTrue(result > 0);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryCountWhereAsynchronous()
		{
			var result = Database.User.CountAsync(w => w.UserId == 1);
			Assert.IsTrue(result.Result > 0);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryFirstOrDefault()
		{
			var result = Database.User.FirstOrDefault();
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultAsynchronous()
		{
			var result = Database.User.FirstOrDefaultAsync();
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultInclude()
		{
			var result = Database.User.FirstOrDefault(i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultIncludeAsynchronous()
		{
			var result = Database.User.FirstOrDefaultAsync(i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhere()
		{
			var result = Database.User.FirstOrDefault(w => w.UserId == 1);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhereAsynchronous()
		{
			var result = Database.User.FirstOrDefaultAsync(w => w.UserId == 1);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhereInclude()
		{
			var result = Database.User.FirstOrDefault(w => w.UserId == 1, i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhereIncludeAsynchronous()
		{
			var result = Database.User.FirstOrDefaultAsync(w => w.UserId == 1, i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryLastOrDefault()
		{
			var result = Database.User.LastOrDefault();
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultAsynchronous()
		{
			var result = Database.User.LastOrDefaultAsync();
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultInclude()
		{
			var result = Database.User.LastOrDefault(i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultIncludeAsynchronous()
		{
			var result = Database.User.LastOrDefaultAsync(i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultWhere()
		{
			var result = Database.User.LastOrDefault(w => w.UserId == 1);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultWhereAsynchronous()
		{
			var result = Database.User.LastOrDefaultAsync(w => w.UserId == 1);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultWhereInclude()
		{
			var result = Database.User.LastOrDefault(w => w.UserId == 1, i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultWhereIncludeAsynchronous()
		{
			var result = Database.User.LastOrDefaultAsync(w => w.UserId == 1, i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryList()
		{
			var result = Database.User.List();
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListAsynchronous()
		{
			var result = Database.User.ListAsync();
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListInclude()
		{
			var result = Database.User.List(i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListIncludeAsynchronous()
		{
			var result = Database.User.ListAsync(i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListPaged()
		{
			var result = Database.User.List(new PagedListParameters());
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListPagedInclude()
		{
			var result = Database.User.List(new PagedListParameters(), i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListPagedWhere()
		{
			var result = Database.User.List(new PagedListParameters(), w => w.UserId == 1);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListPagedWhereInclude()
		{
			var result = Database.User.List(new PagedListParameters(), w => w.UserId == 1, i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListWhere()
		{
			var result = Database.User.List(w => w.UserId == 1);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListWhereAsynchronous()
		{
			var result = Database.User.ListAsync(w => w.UserId == 1);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListWhereInclude()
		{
			var result = Database.User.List(w => w.UserId == 1, i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryListWhereIncludeAsynchronous()
		{
			var result = Database.User.ListAsync(w => w.UserId == 1, i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryQueryable()
		{
			var result = Database.User.Queryable.OrderByDescending(o => o.UserId).FirstOrDefault();
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhere()
		{
			var result = Database.User.SingleOrDefault(w => w.UserId == 1);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhereAsynchronous()
		{
			var result = Database.User.SingleOrDefaultAsync(w => w.UserId == 1);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhereInclude()
		{
			var result = Database.User.SingleOrDefault(w => w.UserId == 1, i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhereIncludeAsynchronous()
		{
			var result = Database.User.SingleOrDefaultAsync(w => w.UserId == 1, i => i.UsersLogs, i => i.UsersRoles);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void DatabaseUnitOfWorkUserRepositoryUpdate()
		{
			var guid = Guid.NewGuid();
			var user = Database.User.SingleOrDefault(w => w.UserId == 1L);
			user.Name = guid.ToString();
			Database.User.Update(user, 1L);
			Database.SaveChanges();
			user = Database.User.SingleOrDefault(w => w.UserId == 1L);

			Assert.AreEqual(user.Name, guid.ToString());
		}

		private void SeedDatabase()
		{
			for (var i = 1; i < 100; i++)
			{
				var user = new UserModel
				{
					Name = $"Name {i}",
					Surname = $"Surname {i}",
					Email = $"email{i}@email.com",
					Login = $"login{i}",
					Password = $"password{i}",
					Status = Status.Active
				};

				user.UsersRoles.Add(new UserRoleModel { Role = Roles.Admin });

				Database.User.Add(user);
			}

			Database.SaveChanges();
		}
	}
}
