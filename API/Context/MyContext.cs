using API.Models;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetailss { get; set; }
        public DbSet<Salesdetails> SalesDetailss { get; set; }
        public DbSet<Selling> Sellings { get; set; }
        public DbSet<Users> Userss { get; set; }
    }
}