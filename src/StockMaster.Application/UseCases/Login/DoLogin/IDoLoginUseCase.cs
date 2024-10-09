using StockMaster.Communication.Requests;
using StockMaster.Communication.Responses;

namespace StockMaster.Application.UseCases.Login.DoLogin;
public interface IDoLoginUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}
