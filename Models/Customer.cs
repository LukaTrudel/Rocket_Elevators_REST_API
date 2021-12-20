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

       

        public string FullName { get; set; }
        public DateTime dateCreation { get; set; }
        
        
        public string Description { get; set; }
        public string FullNameTechnicalAuthority { get; set; }
        public string TechnicalAuthorityPhone{ get; set; }
        public string TechnicalAuthorityEmail { get; set; }

        public long userId { get; set; }
        public long addressId { get; set; }


        // public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        

        [System.Text.Json.Serialization.JsonIgnore]

        public virtual ICollection<Building> Buildings { get; set; }
    }
}