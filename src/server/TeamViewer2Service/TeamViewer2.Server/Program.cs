using Microsoft.AspNetCore;

namespace TeamViewer2.Server
{
    public class Starter
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("TeamViewer2 Server Started.");

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:32767/")
                .UseStartup<App>();
        }
    }
}
