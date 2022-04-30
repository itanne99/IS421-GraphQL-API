using System;
using System.Linq;
using GraphQL_API.Database;
using GraphQL_API.Models;

namespace GraphQL_API.Services
{
    public class UserService : IUser
    {
        private readonly GraphQLDbContext _dbContext;

        public UserService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users.AsQueryable();
        }

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}