using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Solution.Web.UserInterface
{
	public static class Program
	{
		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}
	}
}
