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
        //Users
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> Users([Service] IUser _userService)
        {
            return _userService.GetAll();
        }
        
        public IQueryable<User> AllUsers([Service] IUser _userService)
        {
            return _userService.GetAll();
        }

        public User User([Service] IUser _userService, int id)
        {
            var user = _userService.GetById(id);
            if (user == null) throw new ArgumentException("User not found @ id", nameof(id));
            return user;
        }
        
        //Posts
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> Posts([Service] IPost _postService)
        {
            return _postService.GetAll();
        }
        
        public IQueryable<Post> AllPosts([Service] IPost _postService)
        {
            return _postService.GetAll();
        }

        public Post Post([Service] IPost _postService, int id)
        {
            var post = _postService.GetById(id);
            if (post == null) throw new ArgumentException("Post not found @ id", nameof(id));
            return post;
        }
        
        //Comments
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Comment> Comments([Service] IComment _commentService)
        {
            return _commentService.GetAll();
        }
        
        public IQueryable<Comment> AllComments([Service] IComment _commentService)
        {
            return _commentService.GetAll();
        }

        public Comment Comment([Service] IComment _commentService, int id)
        {
            var comment = _commentService.GetById(id);
            if (comment == null) throw new ArgumentException("Comment not found @ id", nameof(id));
            return comment;
        }
    }
}