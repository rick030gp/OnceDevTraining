using Microsoft.EntityFrameworkCore;
using OnceDev.Training.Infrastructure.Repository;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<NorthwindDbContext>(opt =>
                    opt.UseSqlServer(connectionString,
                    options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                )
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var assembly = typeof(CustomerRepository).Assembly;
            var repositories = assembly.GetTypes().Where(t => !t.IsAbstract && t.Name.EndsWith("Repository"));
            foreach (var repository in repositories)
            {
                var repoInterface = repository.GetInterfaces().FirstOrDefault(t => t.Name.EndsWith(repository.Name));
                services.AddTransient(repoInterface, repository);
            }
            return services;
        }
    }
}
