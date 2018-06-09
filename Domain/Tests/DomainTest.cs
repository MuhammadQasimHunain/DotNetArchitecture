using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.Domain.Domains;
using Solution.Infrastructure.Database;

namespace Solution.Domain.Tests
{
	[TestClass]
	public class DomainTest
	{
		public DomainTest()
		{
			DependencyInjector.RegisterServices();
			DependencyInjector.AddDbContextInMemoryDatabase<DatabaseContext>();
			UserDomain = DependencyInjector.GetService<IUserDomain>();
		}

		IUserDomain UserDomain { get; }

		[TestMethod]
		public void UserDomainSelect()
		{
			var user = UserDomain.Select(0);
			Assert.IsNull(user);
		}
	}
}
