using System;
using System.Collections.Generic;

namespace RocketApi.Models
{
    public class Building
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long AddressId { get; set; }

        public string emailAdministrator { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public virtual ICollection<Battery> Batteries { get; set;}

        public  Customer Customer { get; set; }

        

    }
}

