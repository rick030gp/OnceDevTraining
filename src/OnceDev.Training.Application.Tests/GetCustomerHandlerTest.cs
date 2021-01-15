using FluentAssertions;
using GenFu;
using Moq;
using OnceDev.Training.Application.Customer.Queries;
using OnceDev.Training.Application.Tests.Builders;
using OnceDev.Training.Infrastructure.Repository;
using System.Threading.Tasks;
using Xunit;

namespace OnceDev.Training.Application.Tests
{
    public class GetCustomerHandlerTest
    {
        [Fact]
        public async Task GetCustomerHandler__Handle__GetOneCustomer()
        {
            //Arrange
            var customerId = 1;
            var customer = A.New<Domain.Customer>();
            customer.Id = customerId;

            var repository = new CustomerRepositoryBuilder()
                            .WithSpecificCustomerFindByIdAsync(customer)
                            .Build();

            var request = new GetCustomerQuery { Id = customerId };

            var handler = new GetCustomerHandler(repository);
            //Act
            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            //Assert
            result.Should().BeSameAs(customer);
        }
    }
}
