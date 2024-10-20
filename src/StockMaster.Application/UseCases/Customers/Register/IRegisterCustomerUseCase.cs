using StockMaster.Communication.Requests.Customers;

namespace StockMaster.Application.UseCases.Customers.Register;
public interface IRegisterCustomerUseCase
{
    Task Execute(RequestRegisterCustomerJson request);
}
