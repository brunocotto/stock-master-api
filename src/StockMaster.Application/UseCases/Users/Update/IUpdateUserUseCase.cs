using StockMaster.Communication.Requests;

namespace StockMaster.Application.UseCases.Users.Update;
public interface IUpdateUserUseCase
{
    Task Execute(RequestUpdateUserJson request);
}
