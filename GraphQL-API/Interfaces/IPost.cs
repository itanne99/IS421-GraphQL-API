using System.Linq;
using GraphQL_API.Models;

namespace GraphQL_API.Services
{
    public interface IPost
    {
        void Add(Post post);
        void Delete(int id);
        IQueryable<Post> GetAll();
        Post GetById(int id);
        Post Update(Post post);
    }
}