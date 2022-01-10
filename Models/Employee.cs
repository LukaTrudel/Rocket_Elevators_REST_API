using System;
using System.Collections.Generic;

#nullable disable

namespace RocketApi.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Batteries = new HashSet<Battery>();
            InterventionAuthors = new HashSet<Interventions>();
            InterventionEmployees = new HashSet<Interventions>();
        }

        public long Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string email { get; set; }
        public long? user_id { get; set; }

        // public virtual User User { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
        public virtual ICollection<Interventions> InterventionAuthors { get; set; }
        public virtual ICollection<Interventions> InterventionEmployees { get; set; }
    }
}