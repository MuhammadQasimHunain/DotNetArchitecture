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
			Logger = DependencyInjector.GetService<ILogger>();
		}

		ILogger Logger { get; }

		[TestMethod]
		public void LoggerError()
		{
			Logger.Error(nameof(Logger.Error));
		}

		[TestMethod]
		public void LoggerInformation()
		{
			Logger.Information(nameof(Logger.Information));
		}
	}
}
