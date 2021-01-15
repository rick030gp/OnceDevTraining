using MediatR;
using OnceDev.Training.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnceDev.Training.Application.Customer.Queries
{
    public class GetCustomerQuery : IRequest<Domain.Customer>
    {
        public int Id { get; set; }
    }

    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Domain.Customer>
    {
        private readonly ICustomerRepository _repository;
        public GetCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Domain.Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FindById(request.Id);
        }
    }
}
