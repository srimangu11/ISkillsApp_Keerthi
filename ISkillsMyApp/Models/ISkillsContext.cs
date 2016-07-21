using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ISkillsMyApp.Models
{
    public class ISkillsContext : DbContext
    {
        public ISkillsContext()
        {
            Database.Connection.ConnectionString = "Server=tcp:bookstore1.database.windows.net,1433;Database=BookStore;User ID=test1@bookstore1;Password=Welcome1;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }

    }
}