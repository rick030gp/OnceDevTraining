using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnceDev.Training.Api.IntegrationTests.Configuration
{
    public class StartupTest
    {
        public StartupTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddApplicationPart(typeof(Controllers.CustomerController).Assembly)
                .AddValidators();

            services
                .AddApplication()
                .AddInfrastructure(Configuration.GetConnectionString("northwind_test"));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCustomException();              

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
