using Application.Common;
using Application.Common.Behaviors;
using Application.Common.Mapping;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationConfigureServices(
            this IServiceCollection services, 
            IConfiguration configuration)
            => services
            .Configure<ApplicationSettings>(
                configuration.GetSection(nameof(ApplicationSettings)), 
                options => options.BindNonPublicProperties = true)
            .AddMediatR(Assembly.GetExecutingAssembly())
            //.AddEventHandlers()
            .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        private static IServiceCollection AddAutoMapperProfile(
        this IServiceCollection services,
        Assembly assembly)
        => services
            .AddAutoMapper(
                (_, config) => config
                    .AddProfile(new MappingProfile(assembly)),
                Array.Empty<Assembly>());

    }
}