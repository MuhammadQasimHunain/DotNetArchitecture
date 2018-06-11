using System;
using Serilog;
using Serilog.Events;
using Solution.CrossCutting.Utils;

namespace Solution.CrossCutting.Logging
{
	public class Logger : ILogger
	{
		readonly Serilog.ILogger _loggerAll = new LoggerConfiguration().WriteTo.RollingFile("all.log").CreateLogger();
		readonly Serilog.ILogger _loggerError = new LoggerConfiguration().WriteTo.RollingFile("errors.log").CreateLogger();

		public void Error(Exception exception)
		{
			Error(exception.GetDetail());
		}

		public void Error(string message)
		{
			_loggerAll.Error(message);
			_loggerError.Error(message);
		}

		public void Information(string message)
		{
			_loggerAll.Information(message);
		}
	}
}
