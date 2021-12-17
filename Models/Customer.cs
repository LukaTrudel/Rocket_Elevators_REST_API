using System;
using System.Collections.Generic;

namespace RocketApi.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string ContactPhone { get; set; }

        public string compagnyName { get; set; }
        public string Email { get; set; }
        public DateTime Created_at { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public virtual ICollection<Building> Buildings { get; set; }
    }
}