using OnceDev.Training.Domain;

namespace OnceDev.Training.Infrastructure.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(NorthwindDbContext context) : base(context)
        {
        }
    }
}
