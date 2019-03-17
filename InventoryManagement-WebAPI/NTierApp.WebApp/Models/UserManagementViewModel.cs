using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierApp.WebApp.Models
{
    public class UserManagementViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public int MyProperty { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string Name { get; set; }

       // public IEnumerable<IdentityRole> Name { get; set; }

    }
}