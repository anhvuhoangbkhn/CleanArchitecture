using Application;
using BookStoreWeb.Configurations;
using BookStoreWeb.Extensions;
using Domain;
using Infrastructure;

namespace BookStoreWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
            .AddDomainConfigureServices()
            .AddApplicationConfigureServices(this.Configuration)
            .AddInfrastructureConfigureServices(this.Configuration)
            .AddWebConfigureServices();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseSwagger(env)
                .UseExceptionHandling(env)
                //.UseValidationExceptionHandler()
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                //.UseAuthentication()
                //.UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapControllers());
                //.Initialize();
    }
}
