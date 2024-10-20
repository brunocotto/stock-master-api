using FluentValidation;
using StockMaster.Communication.Requests.Products;
using StockMaster.Exception;

namespace StockMaster.Application.UseCases.Products.Register;

public class RegisterProductValidator : AbstractValidator<RequestRegisterProductJson>
{
    public RegisterProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.NAME_REQUIRED);

        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.DESCRIPTION_REQUIRED);

        RuleFor(p => p.Barcode)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.BARCODE_REQUIRED);

        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ResourceErrorMessages.STOCK_QUANTITY_INVALID);

        RuleFor(p => p.PurchasePrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ResourceErrorMessages.PURCHASE_PRICE_INVALID);

        RuleFor(p => p.ExpiryDate)
            .GreaterThan(DateTime.Now)
            .WithMessage(ResourceErrorMessages.EXPIRY_DATE_VALIDATION_INVALID);


    }
}
