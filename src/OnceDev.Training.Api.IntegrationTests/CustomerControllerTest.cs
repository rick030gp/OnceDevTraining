using Alba;
using FluentAssertions;
using OnceDev.Training.Api.IntegrationTests.Builders;
using OnceDev.Training.Api.IntegrationTests.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OnceDev.Training.Api.IntegrationTests
{
    public class CustomerControllerTest : IClassFixture<Fixture>
    {
        private readonly Fixture _fixture;
        private readonly string _url = "/api/customer";

        public CustomerControllerTest(Fixture fixture)
        {
            _fixture = fixture;
            _fixture.ResetState().GetAwaiter().GetResult();
        }

        [Fact]
        public async Task Verify_Get_200StatusCode()
        {
            new CustomerBuilder(_fixture.context).With10Customers();

            var result = await _fixture.sut.GetAsJson<List<Domain.Customer>>(_url);

            result.Count().Should().Be(10);            
        }
    }
}
