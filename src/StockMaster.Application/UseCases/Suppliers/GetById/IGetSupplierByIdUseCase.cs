using StockMaster.Communication.Responses.Suppliers;

namespace StockMaster.Application.UseCases.Suppliers.GetById;
public interface IGetSupplierByIdUseCase
{
    Task<ResponseSupplierJson> Execute(long id);
}
