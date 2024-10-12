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
    public DbSet<SalesOrder> SalesOrders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Products)
        .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Supplier)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SupplierId);

        base.OnModelCreating(modelBuilder);
    }

}
