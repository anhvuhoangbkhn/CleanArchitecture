

namespace BookStoreWeb
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host
                .CreateDefaultBuilder(args)
                //.UseSerilog((context, services, logger) => logger
                //    .ReadFrom.Configuration(context.Configuration)
                //    .ReadFrom.Services(services)
                //    .Enrich.FromLogContext()
                //    .WriteTo.Console())
                .ConfigureWebHostDefaults(webBuilder => webBuilder
                    .UseStartup<Startup>());
    }
}