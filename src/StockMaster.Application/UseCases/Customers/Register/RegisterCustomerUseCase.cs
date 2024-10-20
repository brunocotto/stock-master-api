using AutoMapper;
using StockMaster.Communication.Requests.Customers;
using StockMaster.Domain.Repositories;
using StockMaster.Domain.Repositories.Customer;
using FluentValidation.Results;
using StockMaster.Exception;
using StockMaster.Exception.ExceptionsBase;

namespace StockMaster.Application.UseCases.Customers.Register;

public class RegisterCustomerUseCase(
    ICustomerWriteOnlyRepository customerWriteOnlyRepository,
    ICustomerReadOnlyRepository customerReadOnlyRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRegisterCustomerUseCase
{
    private readonly ICustomerWriteOnlyRepository _customerWriteOnlyRepository = customerWriteOnlyRepository;
    private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository = customerReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task Execute(RequestRegisterCustomerJson request)
    {
        await Validate(request);
    }

    private async Task Validate(RequestRegisterCustomerJson request)
    {
        var result = new RegisterCustomerValidator().Validate(request);

        var emailExist = await _customerReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

        var customer = _mapper.Map<Domain.Entities.Customer>(request);

        await _customerWriteOnlyRepository.Add(customer);

        await _unitOfWork.Commit();

        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_EXIST));
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
