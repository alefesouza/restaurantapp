using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.SQLite
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./RestaurantApp.db");
        }
    }
}