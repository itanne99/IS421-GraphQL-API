using System;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public User User { get; set; }
    }
}