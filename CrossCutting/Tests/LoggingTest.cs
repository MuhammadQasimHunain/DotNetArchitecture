using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Logging;
using Solution.CrossCutting.Utils;

namespace Solution.CrossCutting.Tests
{
	[TestClass]
	public class LoggingTest
	{
		public LoggingTest()
		{
			DependencyInjector.RegisterServices();
			Logging = DependencyInjector.GetService<ILogger>();
		}

		ILogger Logging { get; }

		[TestMethod]
		public void LoggingError()
		{
			Logging.Error(new DomainException(nameof(LoggingTest)));
		}

		[TestMethod]
		public void LoggingInformation()
		{
			Logging.Information(nameof(LoggingTest));
		}
	}
}
