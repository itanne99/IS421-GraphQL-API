using System;
using System.Linq;
using GraphQL_API.Database;
using GraphQL_API.Models;

namespace GraphQL_API.Services
{
    public class CommentService : IComment
    {
        private readonly GraphQLDbContext _dbContext;

        public CommentService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Add(Comment comment)
        {
            comment.CreatedDateTime = DateTime.Now;
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = GetById(id);
            if (comment != null)
            {
                _dbContext.Comments.Remove(comment);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable<Comment> GetAll()
        {
            return _dbContext.Comments.AsQueryable();
        }

        public Comment GetById(int id)
        {
            return _dbContext.Comments.FirstOrDefault(u => u.Id == id);
        }

        public Comment Update(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
            return comment;
        }
    }
}