using AutoMapper;
using StockMaster.Communication.Requests.Products;
using StockMaster.Domain.Repositories;
using StockMaster.Domain.Repositories.Category;
using StockMaster.Domain.Repositories.Product;
using StockMaster.Domain.Repositories.Supplier;
using StockMaster.Exception;
using StockMaster.Exception.ExceptionsBase;

namespace StockMaster.Application.UseCases.Products.Register;

public class RegisterProductUseCase(
        IProductWriteOnlyRepository productWriteOnlyRepository,
        ICategoryReadOnlyRepository categoryReadOnlyRepository,
        ISupplierReadOnlyRepository supplierReadOnlyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IRegisterProductUseCase
{
    private readonly IProductWriteOnlyRepository _productWriteOnlyRepository = productWriteOnlyRepository;
    private readonly ICategoryReadOnlyRepository _categoryReadOnlyRepository = categoryReadOnlyRepository;
    private readonly ISupplierReadOnlyRepository _supplierReadOnlyRepository = supplierReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task Execute(RequestRegisterProductJson request)
    {
        Validate(request);

        _ = await _categoryReadOnlyRepository.GetById(request.CategoryId) ?? throw new NotFoundException(ResourceErrorMessages.CATEGORY_NOT_FOUND);

        _ = await _supplierReadOnlyRepository.GetById(request.SupplierId) ?? throw new NotFoundException(ResourceErrorMessages.SUPPLIER_NOT_FOUND);

        var product = _mapper.Map<Domain.Entities.Product>(request);

        await _productWriteOnlyRepository.Add(product);

        await _unitOfWork.Commit();
    }

    private static void Validate(RequestRegisterProductJson request)
    {
        var result = new RegisterProductValidator().Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
