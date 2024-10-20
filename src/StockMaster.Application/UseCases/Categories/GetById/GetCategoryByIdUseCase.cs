using AutoMapper;
using StockMaster.Communication.Responses.Categories;
using StockMaster.Domain.Repositories.Category;
using StockMaster.Exception;
using StockMaster.Exception.ExceptionsBase;

namespace StockMaster.Application.UseCases.Categories.GetById;

public class GetCategoryByIdUseCase(
        ICategoryReadOnlyRepository categoryReadOnlyRepository,
        IMapper mapper
    ) : IGetCategoryByIdUseCase
{
    private readonly ICategoryReadOnlyRepository _categoryReadOnlyRepository = categoryReadOnlyRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<ResponseCategoryJson> Execute(long id)
    {
        var result = await _categoryReadOnlyRepository.GetById(id);

        return result is null
            ? throw new NotFoundException(ResourceErrorMessages.CATEGORY_NOT_FOUND)
            : _mapper.Map<ResponseCategoryJson>(result);
    }
}
