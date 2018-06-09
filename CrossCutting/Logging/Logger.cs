using System;

namespace Solution.CrossCutting.Logging
{
	public class Logger : ILogger
	{
		public void Error(Exception exception)
		{
			// exception.GetDetail()
		}

		public void Information(string message)
		{
			// message
		}
	}
}
