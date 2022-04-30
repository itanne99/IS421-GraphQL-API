using System.Linq;
using GraphQL_API.Models;

namespace GraphQL_API.Services
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Delete(int id);
        IQueryable<Customer> GetAll();
        Customer GetById(int id);
        Customer Update(Customer customer);
    }
}