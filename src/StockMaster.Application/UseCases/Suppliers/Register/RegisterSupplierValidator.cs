using FluentValidation;
using StockMaster.Communication.Requests.Suppliers;
using StockMaster.Exception;

namespace StockMaster.Application.UseCases.Suppliers.Register;

public class RegisterSupplierValidator : AbstractValidator<RequestRegisterSupplierJson>
{
    public RegisterSupplierValidator()
    {
        RuleFor(s => s.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED);
        RuleFor(s => s.Contact).NotEmpty().WithMessage(ResourceErrorMessages.CONTACT_REQUIRED);
        RuleFor(s => s.Address).NotEmpty().WithMessage(ResourceErrorMessages.ADRESS_REQUIRED);
        RuleFor(s => s.Cnpj).NotEmpty().WithMessage(ResourceErrorMessages.CNPJ_REQUIRED);
        RuleFor(s => s.Phone).NotEmpty().WithMessage(ResourceErrorMessages.PHONE_REQUIRED);
        RuleFor(s => s.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EMAIL_REQUIRED)
            .EmailAddress()
            .When(s => string.IsNullOrWhiteSpace(s.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ResourceErrorMessages.EMAIL_INVALID);
    }
}
