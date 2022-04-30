using System;
using System.Linq;
using GraphQL_API.Models;
using GraphQL_API.Services;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;

namespace GraphQL_API.GraphQL
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> Customers([Service] ICustomerRepository _customerRepository)
        {
            return _customerRepository.GetAll();
        }
        
        public IQueryable<Customer> AllCustomers([Service] ICustomerRepository _customerRepository)
        {
            return _customerRepository.GetAll();
        }

        public Customer Customer([Service] ICustomerRepository _customerRepository, int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null) throw new ArgumentException("Customer not found @ id", nameof(id));
            return customer;
        }
    }
}