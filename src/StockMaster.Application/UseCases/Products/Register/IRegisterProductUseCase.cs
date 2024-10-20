using StockMaster.Communication.Requests.Products;

namespace StockMaster.Application.UseCases.Products.Register;
public interface IRegisterProductUseCase
{
    Task Execute(RequestRegisterProductJson request);
}
