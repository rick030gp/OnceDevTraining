using AutoMapper;
using MediatR;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
