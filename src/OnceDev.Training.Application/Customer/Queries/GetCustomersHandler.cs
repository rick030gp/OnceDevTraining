using MediatR;
using OnceDev.Training.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnceDev.Training.Application.Customer.Queries
{
    public class GetCustomersQuery : IRequest<IEnumerable<Domain.Customer>>
    {
    }

    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Domain.Customer>>
    {
        private readonly ICustomerRepository _repository;
        public GetCustomersHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Domain.Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.List();
        }
    }
}
