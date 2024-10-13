using FluentValidation;
using StockMaster.Communication.Requests.Categories;
using StockMaster.Exception;

namespace StockMaster.Application.UseCases.Categories.Register;

public class RegisterCategoryValidator : AbstractValidator<RequestRegisterCategoryJson>
{
    public RegisterCategoryValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED);
        RuleFor(c => c.Description).NotEmpty().WithMessage(ResourceErrorMessages.DESCRIPTION_REQUIRED);
    }
}
