using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockMaster.Domain.Repositories;
using StockMaster.Domain.Repositories.Category;
using StockMaster.Domain.Repositories.Customer;
using StockMaster.Domain.Repositories.OrderItem;
using StockMaster.Domain.Repositories.Product;
using StockMaster.Domain.Repositories.SalesOrder;
using StockMaster.Domain.Repositories.StockMovement;
using StockMaster.Domain.Repositories.Supplier;
using StockMaster.Domain.Repositories.User;
using StockMaster.Domain.Security.Cryptography;
using StockMaster.Domain.Security.Tokens;
using StockMaster.Domain.Services.LoggedUser;
using StockMaster.Infrastructure.DataAccess;
using StockMaster.Infrastructure.DataAccess.Repositories;
using StockMaster.Infrastructure.Security.Cryptography;
using StockMaster.Infrastructure.Security.Tokens;
using StockMaster.Infrastructure.Services.LoggedUser;

namespace StockMaster.Infrastructure;

public static class DependecyInjectionExtension
{
    //Método de extensão
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddReposiotires(services);
        AddCryptography(services);
        AddToken(services, configuration);
    }

    private static void AddReposiotires(IServiceCollection services)
    {
        services.AddScoped<IUserReadOnlyRepository, UsersRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UsersRepository>();
        services.AddScoped<IUserUpdateOnlyRepository, UsersRepository>();

        services.AddScoped<ICustomerReadOnlyRepository, CustomersRepository>();
        services.AddScoped<ICustomerWriteOnlyRepository, CustomersRepository>();
        services.AddScoped<ICustomerUpdateOnlyRepository, CustomersRepository>();

        services.AddScoped<ISupplierReadOnlyRepository, SuppliersRepository>();
        services.AddScoped<ISupplierWriteOnlyRepository, SuppliersRepository>();
        services.AddScoped<ISupplierUpdateOnlyRepository, SuppliersRepository>();

        services.AddScoped<IProductReadOnlyRepository, ProductsRepository>();
        services.AddScoped<IProductWriteOnlyRepository, ProductsRepository>();
        services.AddScoped<IProductUpdateOnlyRepository, ProductsRepository>();

        services.AddScoped<ICategoryReadOnlyRepository, CategoriesRepository>();
        services.AddScoped<ICategoryWriteOnlyRepository, CategoriesRepository>();
        services.AddScoped<ICategoryUpdateOnlyRepository, CategoriesRepository>();

        services.AddScoped<ISalesOrderReadOnlyRepository, SalesOrdersRepository>();
        services.AddScoped<ISalesOrderWriteOnlyRepository, SalesOrdersRepository>();
        services.AddScoped<ISalesOrderUpdateOnlyRepository, SalesOrdersRepository>();

        services.AddScoped<IOrderItemReadOnlyRepository, OrderItemsRepository>();
        services.AddScoped<IOrderItemWriteOnlyRepository, OrderItemsRepository>();
        services.AddScoped<IOrderItemUpdateOnlyRepository, OrderItemsRepository>();

        services.AddScoped<IStockMovementReadOnlyRepository, StockMovementsRepository>();
        services.AddScoped<IStockMovementWriteOnlyRepository, StockMovementsRepository>();
        services.AddScoped<IStockMovementUpdateOnlyRepository, StockMovementsRepository>();


        services.AddScoped<IUnitOfWork, UnitOfWork>();    
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 38));

        services.AddDbContext<StockMasterDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }

    private static void AddCryptography(IServiceCollection services)
    {
        services.AddScoped<IPasswordEncripter, Bcrypt>();
        services.AddScoped<ILoggedUser, LoggedUser>();
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }
}
