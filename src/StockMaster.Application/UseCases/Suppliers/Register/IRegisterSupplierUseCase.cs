using StockMaster.Communication.Requests.Suppliers;

namespace StockMaster.Application.UseCases.Suppliers.Register;
public interface IRegisterSupplierUseCase
{
    Task Execute(RequestRegisterSupplierJson request);
}
