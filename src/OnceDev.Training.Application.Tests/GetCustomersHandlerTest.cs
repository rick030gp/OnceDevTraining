using FluentAssertions;
using OnceDev.Training.Application.Customer.Queries;
using OnceDev.Training.Application.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnceDev.Training.Application.Tests
{
    public class GetCustomersHandlerTest
    {
        [Fact]
        public async Task GetCustomersHandler__Handle__GetListOfCustomers()
        {

            var request = new GetCustomersQuery();
            var repository = new CustomerRepositoryBuilder().With10Customers().Build();
            var handler = new GetCustomersHandler(repository);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            result.Count().Should().Be(10);
        }
    }
}
