using StockMaster.Communication.Requests.Users;
using StockMaster.Communication.Responses.Users;

namespace StockMaster.Application.UseCases.Users.Register;
public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
