using System;
using System.ComponentModel.DataAnnotations;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL_API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastEdited { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
    
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Authorize();
            base.Configure(descriptor);
        }
    }
}