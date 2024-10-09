using StockMaster.Communication.Responses;

namespace StockMaster.Application.UseCases.Users.Profile;
public interface IGetUserProfileUseCase
{
    Task<ResponseUserProfileJson> Execute();
}
