using MediatR;
using OnceDev.Training.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnceDev.Training.Application.Customer.Queries
{
    //Clase de comando
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
