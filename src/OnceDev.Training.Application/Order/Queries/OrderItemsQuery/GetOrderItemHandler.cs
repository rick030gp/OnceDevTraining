using MediatR;
using OnceDev.Training.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnceDev.Training.Application.Order.Queries.OrderItemsQuery
{
    public class GetOrderItemQuery: IRequest<IEnumerable<Domain.Order>>
    {
    }
    public class GetOrderItemHandler : IRequestHandler<GetOrderItemQuery, IEnumerable<Domain.Order>>
    {
        private readonly IOrderRepository _repository;

        public GetOrderItemHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Domain.Order>> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListWithOrderItemsAsync();
        }
    }
}
