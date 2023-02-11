using Application.Common.Contracts;
using Infrastructure.Catalog.Repositories;
using Infrastructure.Common.Extensions.Configurations;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories();

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        => services
            .AddDbContext<BookStoreDbContext>( options => options.UseSqlServer(
                configuration.GetDefaultConnectionString(), 
                sqlServer => sqlServer.MigrationsAssembly(typeof(BookStoreDbContext).Assembly.FullName)))
            .AddScoped<ICatalogDbContext>(provider => provider.GetService<BookStoreDbContext>()!);

        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IQueryRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}