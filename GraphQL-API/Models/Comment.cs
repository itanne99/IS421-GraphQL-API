using System;
using System.ComponentModel.DataAnnotations;

namespace GraphQL_API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastEdited { get; set; }
        
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        
        public int PostId { get; set; }
        [Required]
        public Post Post { get; set; }
    }
}