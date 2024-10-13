using AutoMapper;
using StockMaster.Communication.Requests.Suppliers;
using StockMaster.Domain.Repositories;
using StockMaster.Domain.Repositories.Supplier;
using StockMaster.Exception.ExceptionsBase;

namespace StockMaster.Application.UseCases.Suppliers.Register;

public class RegisterSupplierUseCase(
        ISupplierWriteOnlyRepository supplierWriteOnlyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IRegisterSupplierUseCase
{
    private readonly ISupplierWriteOnlyRepository _supplierWriteOnlyRepository = supplierWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task Execute(RequestRegisterSupplierJson request)
    {
        Validate(request);

        var supplier = _mapper.Map<Domain.Entities.Supplier>(request);

        await _supplierWriteOnlyRepository.Add(supplier);

        await _unitOfWork.Commit();
    }
    private static void Validate(RequestRegisterSupplierJson request)
    {
        var result = new RegisterSupplierValidator().Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

}
