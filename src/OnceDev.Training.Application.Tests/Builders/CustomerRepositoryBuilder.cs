using Moq;
using OnceDev.Training.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ICustomerRepository Build()
        {
            return _repository.Object;
        }
    }
}
