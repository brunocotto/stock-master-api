using StockMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StockMaster.Infrastructure.DataAccess;

// internal para garantir que CashFlowDbContext só sera executado dentro do prj de infra
internal class StockMasterDbContext: DbContext
{
    public StockMasterDbContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
