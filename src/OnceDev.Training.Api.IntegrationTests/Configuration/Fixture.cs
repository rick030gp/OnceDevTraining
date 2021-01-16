using Alba;
using Microsoft.Extensions.Configuration;
using OnceDev.Training.Infrastructure.Repository;
using Respawn;
using System.Threading.Tasks;

namespace OnceDev.Training.Api.IntegrationTests.Configuration
{
    public class Fixture
    {
        public readonly SystemUnderTest sut;
        public readonly NorthwindDbContext context;
        public readonly static Checkpoint checkpoint = new Checkpoint();
        private readonly string _testingConnectionString;

        public Fixture()
        {
            sut = SystemUnderTest.ForStartup<StartupTest>();
            context = (NorthwindDbContext)sut.Services.GetService(typeof(NorthwindDbContext));
            var configuration = (IConfiguration)sut.Services.GetService(typeof(IConfiguration));
            _testingConnectionString = configuration.GetConnectionString("northwind_test");
        }

        public async Task ResetState()
        {
            await checkpoint.Reset(_testingConnectionString);
        }
    }
}
