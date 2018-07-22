using System;
using System.Collections.Generic;
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
        public void DatabaseUnitOfWorkUserRepositoryAdd()
        {
            var user = CreateUser();
            Database.User.Add(user);
            Database.SaveChanges();
            Assert.IsNotNull(Database.User.Select(user.UserId));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAddAsynchronous()
        {
            var user = CreateUser();
            Database.User.AddAsync(user);
            Database.SaveChanges();
            Assert.IsNotNull(Database.User.Select(user.UserId));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAddRange()
        {
            var count = Database.User.Count();
            Database.User.AddRange(new List<UserModel> { CreateUser() });
            Database.SaveChanges();
            Assert.IsTrue(Database.User.Count() > count);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAddRangeAsynchronous()
        {
            var count = Database.User.Count();
            Database.User.AddRangeAsync(new List<UserModel> { CreateUser() });
            Database.SaveChanges();
            Assert.IsTrue(Database.User.Count() > count);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAny()
        {
            Assert.IsTrue(Database.User.Any());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAnyAsynchronous()
        {
            Assert.IsTrue(Database.User.AnyAsync().Result);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAnyWhere()
        {
            Assert.IsTrue(Database.User.Any(x => x.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAnyWhereAsynchronous()
        {
            Assert.IsTrue(Database.User.AnyAsync(x => x.UserId == 1L).Result);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryCount()
        {
            Assert.IsTrue(Database.User.Count() > 0);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryCountAsynchronous()
        {
            Assert.IsTrue(Database.User.CountAsync().Result > 0);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryCountWhere()
        {
            Assert.IsTrue(Database.User.Count(x => x.UserId == 1) == 1L);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryCountWhereAsynchronous()
        {
            Assert.IsTrue(Database.User.CountAsync(x => x.UserId == 1L).Result == 1L);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryDelete()
        {
            Database.User.Delete(100L);
            Database.SaveChanges();
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryDeleteAsynchronous()
        {
            Database.User.DeleteAsync(100L);
            Database.SaveChanges();
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryDeleteWhere()
        {
            Database.User.Delete(x => x.UserId == 100L);
            Database.SaveChanges();
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryDeleteWhereAsynchronous()
        {
            Database.User.DeleteAsync(x => x.UserId == 100L);
            Database.SaveChanges();
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefault()
        {
            Assert.IsNotNull(Database.User.FirstOrDefault());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultAsynchronous()
        {
            Assert.IsNotNull(Database.User.FirstOrDefaultAsync().Result);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultInclude()
        {
            Assert.IsNotNull(Database.User.FirstOrDefault(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultIncludeAsynchronous()
        {
            Assert.IsNotNull(Database.User.FirstOrDefaultAsync(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhere()
        {
            Assert.IsNotNull(Database.User.FirstOrDefault(x => x.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhereAsynchronous()
        {
            Assert.IsNotNull(Database.User.FirstOrDefaultAsync(x => x.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhereInclude()
        {
            Assert.IsNotNull(Database.User.FirstOrDefault(x => x.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(Database.User.FirstOrDefaultAsync(x => x.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryLastOrDefault()
        {
            Assert.IsNotNull(Database.User.LastOrDefault());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultAsynchronous()
        {
            Assert.IsNotNull(Database.User.LastOrDefaultAsync());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultInclude()
        {
            Assert.IsNotNull(Database.User.LastOrDefault(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultIncludeAsynchronous()
        {
            Assert.IsNotNull(Database.User.LastOrDefaultAsync(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultWhere()
        {
            Assert.IsNotNull(Database.User.LastOrDefault(x => x.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultWhereAsynchronous()
        {
            Assert.IsNotNull(Database.User.LastOrDefaultAsync(x => x.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultWhereInclude()
        {
            Assert.IsNotNull(Database.User.LastOrDefault(x => x.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryLastOrDefaultWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(Database.User.LastOrDefaultAsync(x => x.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryList()
        {
            Assert.IsNotNull(Database.User.List());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListAsynchronous()
        {
            Assert.IsNotNull(Database.User.ListAsync());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListInclude()
        {
            Assert.IsNotNull(Database.User.List(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListIncludeAsynchronous()
        {
            Assert.IsNotNull(Database.User.ListAsync(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPaged()
        {
            Assert.IsNotNull(Database.User.List(new PagedListParameters()));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPagedInclude()
        {
            Assert.IsNotNull(Database.User.List(new PagedListParameters(), i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPagedWhere()
        {
            Assert.IsNotNull(Database.User.List(new PagedListParameters(), x => x.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPagedWhereInclude()
        {
            Assert.IsNotNull(Database.User.List(new PagedListParameters(), x => x.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhere()
        {
            Assert.IsNotNull(Database.User.List(x => x.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhereAsynchronous()
        {
            Assert.IsNotNull(Database.User.ListAsync(x => x.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhereInclude()
        {
            Assert.IsNotNull(Database.User.List(x => x.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(Database.User.ListAsync(x => x.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryQueryable()
        {
            Assert.IsNotNull(Database.User.Queryable.OrderByDescending(o => o.UserId).FirstOrDefault());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySelect()
        {
            Assert.IsNotNull(Database.User.Select(1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySelectAsynchronous()
        {
            Assert.IsNotNull(Database.User.SelectAsync(1L).Result);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhere()
        {
            Assert.IsNotNull(Database.User.SingleOrDefault(x => x.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhereAsynchronous()
        {
            Assert.IsNotNull(Database.User.SingleOrDefaultAsync(x => x.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhereInclude()
        {
            Assert.IsNotNull(Database.User.SingleOrDefault(x => x.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(Database.User.SingleOrDefaultAsync(x => x.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryUpdate()
        {
            var user = Database.User.Select(1L);
            user.Name = Guid.NewGuid().ToString();
            Database.User.Update(user, 1L);
            Database.SaveChanges();
            Assert.AreEqual(user.Name, Database.User.Select(1L).Name);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryUpdateAsynchronous()
        {
            var user = Database.User.Select(1L);
            user.Name = Guid.NewGuid().ToString();
            Database.User.UpdateAsync(user, 1L);
            Database.SaveChanges();
            Assert.AreEqual(user.Name, Database.User.Select(1L).Name);
        }

        private static UserModel CreateUser()
        {
            var guid = Guid.NewGuid().ToString();

            return new UserModel
            {
                Name = $"Name {guid}",
                Surname = $"Surname {guid}",
                Email = $"email{guid}@email.com",
                Login = $"login{guid}",
                Password = $"password{guid}",
                Roles = Roles.User | Roles.Admin,
                Status = Status.Active
            };
        }

        private void SeedDatabase()
        {
            for (var i = 1L; i <= 100; i++)
            {
                Database.User.Add(CreateUser());
            }

            Database.SaveChanges();
        }
    }
}
