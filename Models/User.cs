// using System;
// using System.Collections.Generic;

// #nullable disable

// namespace RocketApi.Models
// {
//     public partial class User
//     {
//         public User()
//         {
//             Customers = new HashSet<Customer>();
//             employees = new HashSet<Employee>();
//         }

//         // public long Id { get; set; }
//         // public string email { get; set; }
//         // public string password { get; set; }
//         // public string ResetPasswordToken { get; set; }
//         // public bool? SuperadminRole { get; set; }
//         // public bool? EmployeeRole { get; set; }
//         // public bool? UserRole { get; set; }

//         public virtual ICollection<Customer> Customers { get; set; }
//         public virtual ICollection<Employee> employees { get; set; }
//     }
// }