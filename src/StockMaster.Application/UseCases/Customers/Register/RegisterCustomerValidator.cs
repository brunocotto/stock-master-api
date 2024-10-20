using FluentValidation;
using StockMaster.Communication.Requests.Customers;
using StockMaster.Exception;

namespace StockMaster.Application.UseCases.Customers.Register;

public class RegisterCustomerValidator : AbstractValidator<RequestRegisterCustomerJson>
{
    public RegisterCustomerValidator()
    {
        RuleFor(p => p.Name)
        .NotEmpty()
            .WithMessage(ResourceErrorMessages.NAME_REQUIRED);

        RuleFor(p => p.Cpf)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.CPF_REQUIRED)
            .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
            .WithMessage(ResourceErrorMessages.CPF_FORMAT_INVALID);

        RuleFor(p => p.Address)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.ADRESS_REQUIRED);

        RuleFor(p => p.Phone)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.PHONE_REQUIRED);

        RuleFor(p => p.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EMAIL_REQUIRED)
            .EmailAddress()
            .When(p => string.IsNullOrWhiteSpace(p.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ResourceErrorMessages.EMAIL_INVALID);
    }
}
