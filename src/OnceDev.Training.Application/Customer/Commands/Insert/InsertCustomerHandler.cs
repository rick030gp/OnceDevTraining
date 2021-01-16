using AutoMapper;
using MediatR;
using OnceDev.Training.Infrastructure.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace OnceDev.Training.Application.Customer.Commands.Insert
{
    public class PostInsertCustomerCommand : Dto.Customer, IRequest<int>
    {   
    }
    public class InsertCustomerHandler : IRequestHandler<PostInsertCustomerCommand, int>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public InsertCustomerHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(PostInsertCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Dto.Customer, Domain.Customer>(request);

            await _repository.InsertAsync(customer);

            return customer.Id;
        }
    }
}
