using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Solution.CrossCutting.AspNetCore
{
	public static class Program
	{
		public static void Main()
		{
			WebHost.CreateDefaultBuilder().Build().Run();
		}
	}
}
