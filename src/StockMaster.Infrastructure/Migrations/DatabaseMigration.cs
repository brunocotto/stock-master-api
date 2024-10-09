using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockMaster.Infrastructure.DataAccess;

namespace CashFlow.Infrastructure.Migrations;

public class DatabaseMigration
{
    public async static Task MigrationDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<StockMasterDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}