using StockMaster.Communication.Requests.Users;

namespace StockMaster.Application.UseCases.Users.Update;
public interface IUpdateUserUseCase
{
    Task Execute(RequestUpdateUserJson request);
}
