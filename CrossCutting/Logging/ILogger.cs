using System;

namespace Solution.CrossCutting.Logging
{
	public interface ILogger
	{
		void Error(Exception exception);

		void Information(string message);
	}
}
