using Microsoft.AspNet.Identity.EntityFramework;
using NTier.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Repository.Context
{
    class InventoryDbContext : IdentityDbContext<ApplicationUser>
    {

        public InventoryDbContext()
                : base("InventoryDbContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

    }
}
