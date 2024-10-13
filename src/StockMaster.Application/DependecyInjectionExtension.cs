using Microsoft.Extensions.DependencyInjection;
using StockMaster.Application.AutoMapper;
using StockMaster.Application.UseCases.Categories.Register;
using StockMaster.Application.UseCases.Login.DoLogin;
using StockMaster.Application.UseCases.Suppliers.Register;
using StockMaster.Application.UseCases.Users.ChangePassword;
using StockMaster.Application.UseCases.Users.Delete;
using StockMaster.Application.UseCases.Users.Profile;
using StockMaster.Application.UseCases.Users.Register;
using StockMaster.Application.UseCases.Users.Update;

namespace StockMaster.Application;

public static class DependecyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        services.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();   
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();   
        services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
        services.AddScoped<IDeleteProfileUseCase, DeleteProfileUseCase>();

        services.AddScoped<IRegisterCategoryUseCase, RegisterCategoryUseCase>();

        services.AddScoped<IRegisterSupplierUseCase, RegisterSupplierUseCase>();
    }
}
