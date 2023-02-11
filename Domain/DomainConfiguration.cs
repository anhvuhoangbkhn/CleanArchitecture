using Domain.Common.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomainConfigureServices(
            this IServiceCollection services)
            => services.AddFactories();

        private static IServiceCollection AddFactories(this IServiceCollection services)
            => services.Scan( 
                scan => scan.FromCallingAssembly().AddClasses(classes => classes.AssignableTo(typeof(IFactory<>)))
                .AsMatchingInterface()
                .WithTransientLifetime());
    }
}