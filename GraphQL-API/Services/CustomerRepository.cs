using System.Linq;
using GraphQL_API.Database;
using GraphQL_API.Models;

namespace GraphQL_API.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly GraphQLDbContext _dbContext;

        public CustomerRepository(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable<Customer> GetAll()
        {
            return _dbContext.Customers.AsQueryable();
        }

        public Customer GetById(int id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer Update(Customer customer)
        {
            var newCustomer = new Customer();
            if (newCustomer.Name != null) newCustomer.Name = customer.Name;
            newCustomer.Code ??= customer.Code;
            newCustomer.CreatedAt = customer.CreatedAt;
            if (newCustomer.Email != null) newCustomer.Email = customer.Email;
            newCustomer.IsBlocked = customer.IsBlocked;
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
            return newCustomer;
        }
    }
}