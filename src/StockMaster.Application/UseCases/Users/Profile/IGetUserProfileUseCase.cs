using StockMaster.Communication.Responses.Users;

namespace StockMaster.Application.UseCases.Users.Profile;
public interface IGetUserProfileUseCase
{
    Task<ResponseUserProfileJson> Execute();
}
