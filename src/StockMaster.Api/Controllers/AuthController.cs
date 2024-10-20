using StockMaster.Application.UseCases.Login.DoLogin;
using Microsoft.AspNetCore.Mvc;
using StockMaster.Communication.Requests.Users;
using StockMaster.Communication.Responses.Users;
using StockMaster.Communication.Responses.Exceptions;

namespace StockMaster.Api.Controllers;

[Route("api/auth/login")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Login(
        [FromServices] IDoLoginUseCase useCase,
        [FromBody] RequestLoginJson request)
    {
        var response = await useCase.Execute(request);

        return Ok(response);
    }
}
