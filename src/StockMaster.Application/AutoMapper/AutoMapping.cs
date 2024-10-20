using AutoMapper;
using StockMaster.Communication.Requests.Categories;
using StockMaster.Communication.Requests.Products;
using StockMaster.Communication.Requests.Suppliers;
using StockMaster.Communication.Requests.Users;
using StockMaster.Communication.Responses.Categories;
using StockMaster.Communication.Responses.Suppliers;
using StockMaster.Communication.Responses.Users;
using StockMaster.Domain.Entities;

namespace StockMaster.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }
    private void RequestToEntity()
    {   
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
        CreateMap<RequestRegisterCategoryJson, Category>();
        CreateMap<RequestRegisterSupplierJson, Supplier>();
        CreateMap<RequestRegisterProductJson, Product>();
    }

    private void EntityToResponse()
    {
        CreateMap<User, ResponseUserProfileJson>();
        CreateMap<Category, ResponseCategoryJson>();
        CreateMap<Supplier, ResponseSupplierJson>();
    }
}
