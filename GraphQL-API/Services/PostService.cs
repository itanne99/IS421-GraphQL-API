using System;
using System.Linq;
using GraphQL_API.Database;
using GraphQL_API.Models;

namespace GraphQL_API.Services
{
    public class PostService : IPost
    {
        private readonly GraphQLDbContext _dbContext;

        public PostService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Add(Post post)
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = GetById(id);
            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable<Post> GetAll()
        {
            return _dbContext.Posts.AsQueryable();
        }

        public Post GetById(int id)
        {
            return _dbContext.Posts.FirstOrDefault(u => u.Id == id);
        }

        public Post Update(Post post)
        {
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
            return post;
        }
    }
}