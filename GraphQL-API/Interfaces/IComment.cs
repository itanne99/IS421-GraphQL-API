using System.Linq;
using GraphQL_API.Models;

namespace GraphQL_API.Services
{
    public interface IComment
    {
        void Add(Comment comment);
        void Delete(int id);
        IQueryable<Comment> GetAll();
        Comment GetById(int id);
        Comment Update(Comment comment);
    }
}