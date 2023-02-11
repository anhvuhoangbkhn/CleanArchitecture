using Application.Common.Contracts;
using Application.Common.Models;
using BookStoreWeb.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Configurations
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebConfigureServices(
            this IServiceCollection services)
        {
            services
                //.AddScoped<ICurrentUser, CurrentUserService>()
                .AddSwaggerGen()
                .AddValidatorsFromAssemblyContaining<Result>()
                .AddControllers()
                .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
