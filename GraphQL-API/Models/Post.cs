using System;
using System.ComponentModel.DataAnnotations;
using HotChocolate;
using HotChocolate.Types;

#nullable enable
namespace GraphQL_API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? HeaderImage { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastEdited { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
    
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Authorize();
            base.Configure(descriptor);
        }
    }
}