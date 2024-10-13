using StockMaster.Communication.Requests.Users;

namespace StockMaster.Application.UseCases.Users.ChangePassword;
public interface IChangePasswordUseCase
{
    Task Execute(RequestChangePasswordJson request);
}
