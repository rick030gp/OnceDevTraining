using GenFu;
using Moq;
using OnceDev.Training.Infrastructure.Repository;
using System.Collections.Generic;

namespace OnceDev.Training.Application.Tests.Builders
{
    public class CustomerRepositoryBuilder
    {
        private readonly Mock<ICustomerRepository> _repository;

        public CustomerRepositoryBuilder()
        {
            _repository = new Mock<ICustomerRepository>();
        }

        public CustomerRepositoryBuilder WithSpecificCustomerFindByIdAsync(Domain.Customer customer)
        {
            _repository.Setup(c => c.FindById(It.Is<int>(id => id == customer.Id)))
                .ReturnsAsync(customer);

            return this;
        }

        public CustomerRepositoryBuilder With10Customers()
        {
            _repository.Setup(c => c.List()).ReturnsAsync(GetCustomers(10));
            return this;
        }

        private List<Domain.Customer> GetCustomers(int quantity)
        {
            return A.ListOf<Domain.Customer>(quantity);
        }
        public ICustomerRepository Build()
        {
            return _repository.Object;
        }
    }
}
