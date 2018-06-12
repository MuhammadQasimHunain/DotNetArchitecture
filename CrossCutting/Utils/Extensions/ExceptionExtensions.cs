using System;
using System.Diagnostics;
using System.Text;

namespace Solution.CrossCutting.Utils
{
	public static class ExceptionExtensions
	{
		public static string GetDetail(this Exception exception)
		{
			var sb = new StringBuilder();

			sb.Append($"Message: '{ exception.Message }'");

			var stackFrame = new StackTrace(exception, true).GetFrame(0);

			if (stackFrame == null)
			{
				return sb.ToString();
			}

			sb.Append($" File: '{ stackFrame.GetMethod().DeclaringType }'");
			sb.Append($" Line: '{ stackFrame.GetFileLineNumber() }'");

			return sb.ToString();
		}
	}
}
