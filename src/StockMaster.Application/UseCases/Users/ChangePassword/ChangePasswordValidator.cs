using StockMaster.Exception;
using FluentValidation;
using StockMaster.Communication.Requests.Users;

namespace StockMaster.Application.UseCases.Users.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.NewPassword).SetValidator(new PasswordValidator<RequestChangePasswordJson>());  
    }
}

