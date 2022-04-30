using System;

namespace GraphQL_API.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int? Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsBlocked { get; set; }
    }
}