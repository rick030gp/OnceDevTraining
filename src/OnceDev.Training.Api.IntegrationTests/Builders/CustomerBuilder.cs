using GenFu;
using OnceDev.Training.Infrastructure.Repository;
using System.Collections.Generic;

namespace OnceDev.Training.Api.IntegrationTests.Builders
{
    public class CustomerBuilder
    {
        private readonly NorthwindDbContext _context;
        public CustomerBuilder(NorthwindDbContext context)
        {
            _context = context;
        }

        public CustomerBuilder With10Customers()
        {
            _context.AddRange(CreateCustomer(10));
            _context.SaveChanges();
            return this;
        }

        private IList<Domain.Customer> CreateCustomer(int quantity)
        {
            A.Configure<Domain.Customer>()
                .Fill(c => c.Id, () => { return 0; });

            return A.ListOf<Domain.Customer>(quantity);
        }
    }
}
