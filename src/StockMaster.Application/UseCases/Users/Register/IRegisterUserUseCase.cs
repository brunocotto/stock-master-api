using StockMaster.Communication.Requests;
using StockMaster.Communication.Responses;

namespace StockMaster.Application.UseCases.Users.Register;
public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
