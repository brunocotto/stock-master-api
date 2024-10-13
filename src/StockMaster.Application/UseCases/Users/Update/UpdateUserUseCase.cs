using StockMaster.Domain.Repositories;
using StockMaster.Domain.Repositories.User;
using StockMaster.Domain.Services.LoggedUser;
using StockMaster.Exception;
using StockMaster.Exception.ExceptionsBase;
using FluentValidation.Results;
using StockMaster.Communication.Requests.Users;

namespace StockMaster.Application.UseCases.Users.Update;

public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly IUserUpdateOnlyRepository _userUpdateOnlyRepository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly ILoggedUser _loggerUser;
    private readonly IUnitOfWork _unitOfWOrk;
    public UpdateUserUseCase(
        IUserUpdateOnlyRepository userUpdateOnlyRepository,
        IUserReadOnlyRepository userReadOnlyRepository,
        ILoggedUser loggerUser,
        IUnitOfWork unitOfWOrk
        )
    {
        _userUpdateOnlyRepository = userUpdateOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
        _loggerUser = loggerUser;
        _unitOfWOrk = unitOfWOrk;
    }
    public async Task Execute(RequestUpdateUserJson request)
    {
        var loggedUser = await _loggerUser.Get();

        await Validate(request, loggedUser.Email);

        var user = await _userUpdateOnlyRepository.GetById(loggedUser.Id);

        user.Name = request.Name;
        user.Email = request.Email;

        _userUpdateOnlyRepository.Update(user);

        await _unitOfWOrk.Commit();
    }

    private async Task Validate(RequestUpdateUserJson request, string currentEmail)
    {
        var validator = new UpdateUserValidator();

        var result = validator.Validate(request);

        if (currentEmail.Equals(request.Email) == false)
        {
            var userExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

            if (userExist) 
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_EXIST));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }

    }
}
