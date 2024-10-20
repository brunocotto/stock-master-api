using AutoMapper;
using StockMaster.Communication.Responses.Suppliers;
using StockMaster.Domain.Repositories.Supplier;
using StockMaster.Exception;
using StockMaster.Exception.ExceptionsBase;

namespace StockMaster.Application.UseCases.Suppliers.GetById;

public class GetSupplierByIdUseCase(
    ISupplierReadOnlyRepository supplierReadOnlyRepository,
    IMapper mapper
    ) : IGetSupplierByIdUseCase
{
    private readonly ISupplierReadOnlyRepository _supplierReadOnlyRepository = supplierReadOnlyRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<ResponseSupplierJson> Execute(long id)
    {
        var result = await _supplierReadOnlyRepository.GetById(id);

        return result is null
            ? throw new NotFoundException(ResourceErrorMessages.SUPPLIER_NOT_FOUND)
            : _mapper.Map<ResponseSupplierJson>(result);
    }
}
