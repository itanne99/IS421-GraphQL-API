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
            return _dbContext.Comments.Select(comment => new Comment
            {
                Id = comment.Id,
                Message = comment.Message,
                Post = new Post
                {
                    Content = comment.Post.Content,
                    Id = comment.Post.Id,
                    Title = comment.Post.Title,
                    User = comment.Post.User,
                    HeaderImage = comment.Post.HeaderImage,
                    LastEdited = comment.Post.LastEdited,
                    UserId = comment.Post.UserId,
                    CreatedDateTime = comment.Post.CreatedDateTime
                },
                User = comment.User,
                LastEdited = comment.LastEdited,
                PostId = comment.PostId,
                UserId = comment.UserId,
                CreatedDateTime = comment.CreatedDateTime
            });
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