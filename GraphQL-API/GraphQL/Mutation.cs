using System;
using GraphQL_API.Models;
using GraphQL_API.Services;
using HotChocolate;

namespace GraphQL_API.GraphQL
{
    public class Mutation
    {
        //User
        public User AddUser([Service] IUser _userService, string first, string last, string email)
        {
            var user = new User
            {
                FirstName = first,
                LastName = last,
                Email = email,
                CreatedDateTime = DateTime.Now,
            };
            _userService.Add(user);
            return user;
        }

        public User UpdateUser([Service] IUser _userService, int id, string? first, string? last, string? email)
        {
            var currUser = _userService.GetById(id);
            if (first != null) currUser.FirstName = first;
            if (last != null) currUser.LastName = last;
            if (email != null) currUser.Email = email;
            currUser.LastEdited = DateTime.Now;
            _userService.Update(currUser);
            return currUser;
        }

        public User DeleteUser(int id, [Service] IUser _userService)
        {
            var userToDelete = _userService.GetById(id);
            if (userToDelete == null) throw new ArgumentException($"User not found @ id:{id}");
            _userService.Delete(id);
            return userToDelete;
        }
        
        //Post
        public Post AddPost([Service] IPost _postService, string title, string? headerImage, string content, int userId)
        {
            var post = new Post
            {
                Title = title,
                HeaderImage = headerImage,
                Content = content,
                CreatedDateTime = DateTime.Now,
                UserId = userId
            };
            _postService.Add(post);
            return post;
        }

        public Post UpdatePost([Service] IPost _postService, int id, string? title, string? headerImage, string? content)
        {
            var currPost = _postService.GetById(id);
            if (title != null) currPost.Title = title;
            if (content != null) currPost.Content = content;
            if (headerImage != null) currPost.HeaderImage = headerImage;
            _postService.Update(currPost);
            return currPost;
        }

        public Post DeletePost(int id, [Service] IPost _postService)
        {
            var currPost = _postService.GetById(id);
            if (currPost == null) throw new ArgumentException($"Post not found @ id:{id}");
            _postService.Delete(id);
            return currPost;
        }
        
        //Comment
        public Comment AddComment([Service] IComment _commentService, string message, int userId, int postId)
        {
            var comment = new Comment
            {
                Message = message,
                UserId = userId,
                PostId = postId,
                CreatedDateTime = DateTime.Now
            };
            _commentService.Add(comment);
            return comment;
        }

        public Comment UpdateComment([Service] IComment _commentService, int id, string? message)
        {
            var currComment = _commentService.GetById(id);
            if (message != null) currComment.Message = message;
            currComment.LastEdited = DateTime.Now;
            _commentService.Update(currComment);
            return currComment;
        }

        public Comment DeleteComment(int id, [Service] IComment _commentService)
        {
            var currComment = _commentService.GetById(id);
            if (currComment == null) throw new ArgumentException($"Comment not found @ id:{id}");
            _commentService.Delete(id);
            return currComment;
        }
    }
}