using AutoMapper;
using StockMaster.Communication.Requests.Categories;
using StockMaster.Domain.Repositories;
using StockMaster.Domain.Repositories.Category;
using StockMaster.Exception.ExceptionsBase;

namespace StockMaster.Application.UseCases.Categories.Register;

public class RegisterCategoryUseCase(
        ICategoryWriteOnlyRepository categoryWriteOnlyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IRegisterCategoryUseCase
{
    private readonly ICategoryWriteOnlyRepository _categoryWriteOnlyRepository = categoryWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task Execute(RequestRegisterCategoryJson request)
    {
        Validate(request);

        var category = _mapper.Map<Domain.Entities.Category>(request);

        await _categoryWriteOnlyRepository.Add(category);

        await _unitOfWork.Commit();
    }

    private static void Validate(RequestRegisterCategoryJson request)
    {
        var result = new RegisterCategoryValidator().Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
