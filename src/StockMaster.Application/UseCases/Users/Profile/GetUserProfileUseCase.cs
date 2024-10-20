using AutoMapper;
using StockMaster.Communication.Responses.Users;
using StockMaster.Domain.Services.LoggedUser;

namespace StockMaster.Application.UseCases.Users.Profile;

public class GetUserProfileUseCase(
    IMapper mapper,
    ILoggedUser loggedUser
    ) : IGetUserProfileUseCase
{
    private readonly IMapper _mapper = mapper;
    private readonly ILoggedUser _loggedUser = loggedUser;

    public async Task<ResponseUserProfileJson> Execute()
    {
        var user = await _loggedUser.Get();

        return _mapper.Map<ResponseUserProfileJson>(user);  
    }
}
