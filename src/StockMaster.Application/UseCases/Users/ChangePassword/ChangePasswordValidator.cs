using StockMaster.Communication.Requests;
using StockMaster.Exception;
using FluentValidation;

namespace StockMaster.Application.UseCases.Users.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.NewPassword).SetValidator(new PasswordValidator<RequestChangePasswordJson>());  
    }
}

