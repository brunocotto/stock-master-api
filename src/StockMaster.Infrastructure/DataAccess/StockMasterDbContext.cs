using StockMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StockMaster.Infrastructure.DataAccess;

internal class StockMasterDbContext: DbContext
{
    public StockMasterDbContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> SalesOrders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
