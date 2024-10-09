
using StockMaster.Domain.Repositories;
using StockMaster.Domain.Repositories.User;
using StockMaster.Domain.Services.LoggedUser;

namespace StockMaster.Application.UseCases.Users.Delete;

public class DeleteProfileUseCase : IDeleteProfileUseCase
{
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly ILoggedUser _loggedUser;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteProfileUseCase(
        IUserWriteOnlyRepository userWriteOnlyRepository,
        ILoggedUser loggedUser,
        IUnitOfWork unitOfWork)
    {
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _loggedUser = loggedUser;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute()
    {
        var user = await _loggedUser.Get();

        await _userWriteOnlyRepository.Delete(user);

        await _unitOfWork.Commit();
    }
}
