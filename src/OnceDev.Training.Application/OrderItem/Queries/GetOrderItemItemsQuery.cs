using MediatR;
using OnceDev.Training.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnceDev.Training.Application.OrderItem.Queries
{
    public class GetOrderItemItemsQuery : IRequest<IEnumerable<Domain.OrderItem>>
    {
    }

    public class GetOrderItemItemsHandler : IRequestHandler<GetOrderItemItemsQuery, IEnumerable<Domain.OrderItem>>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public GetOrderItemItemsHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }


        public async Task<IEnumerable<Domain.OrderItem>> Handle(GetOrderItemItemsQuery request, CancellationToken cancellationToken)
        {
            return await _orderItemRepository.ListWithOrderItemItemsAsync();
        }
    }
}
