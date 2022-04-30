using System.Linq;
using GraphQL_API.Models;

namespace GraphQL_API.Services
{
    public interface IUser
    {
        void Add(User user);
        void Delete(int id);
        IQueryable<User> GetAll();
        User GetById(int id);
        User Update(User user);
    }
}