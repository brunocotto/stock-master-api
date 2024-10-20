using Microsoft.AspNetCore.Mvc;
using StockMaster.Application.UseCases.Customers.Register;
using StockMaster.Communication.Requests.Customers;
using StockMaster.Communication.Responses.Exceptions;

namespace StockMaster.Api.Controllers;
[Route("api/customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Register(
        [FromServices] IRegisterCustomerUseCase useCase,
        [FromBody] RequestRegisterCustomerJson request)
    {
        await useCase.Execute(request);

        return Created();
    }
}
