using StockMaster.Communication.Responses.Categories;

namespace StockMaster.Application.UseCases.Categories.GetById;
public interface IGetCategoryByIdUseCase
{
    Task<ResponseCategoryJson> Execute(long id);
}
