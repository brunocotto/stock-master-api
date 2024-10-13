using AutoMapper;
using StockMaster.Communication.Requests.Categories;
using StockMaster.Communication.Requests.Users;
using StockMaster.Communication.Responses;
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
    }

    private void EntityToResponse()
    {
        CreateMap<User, ResponseUserProfileJson>();
    }
}
