using GraphQL_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Database
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Customer> Customers { get; set; }

    }
}