using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.Application.Applications;
using Solution.CrossCutting.DependencyInjection;
using Solution.Infrastructure.Database;

namespace Solution.Application.Tests
{
	[TestClass]
	public class ApplicationTest
	{
		public ApplicationTest()
		{
			DependencyInjector.RegisterServices();
			DependencyInjector.AddDbContextInMemoryDatabase<DatabaseContext>();
			UserApplication = DependencyInjector.GetService<IUserApplication>();
		}

		IUserApplication UserApplication { get; }

		[TestMethod]
		public void UserApplicationSelect()
		{
			var user = UserApplication.Select(0);
			Assert.IsNull(user);
		}
	}
}
