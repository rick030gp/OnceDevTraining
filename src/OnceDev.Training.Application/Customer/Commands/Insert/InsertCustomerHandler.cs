using MediatR;
using OnceDev.Training.Infrastructure.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace OnceDev.Training.Application.Customer.Commands.Insert
{
    public class PostInsertCustomerCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
    public class InsertCustomerHandler : IRequestHandler<PostInsertCustomerCommand, int>
    {
        private readonly ICustomerRepository _repository;
        public InsertCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(PostInsertCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Customer
            {
                City = request.City,
                Country = request.Country,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone
            };

            await _repository.InsertAsync(customer);

            return customer.Id;
        }
    }
}
