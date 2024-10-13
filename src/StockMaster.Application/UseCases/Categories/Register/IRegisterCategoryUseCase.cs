using StockMaster.Communication.Requests.Categories;

namespace StockMaster.Application.UseCases.Categories.Register;
public interface IRegisterCategoryUseCase
{
    Task Execute(RequestRegisterCategoryJson request);
}
