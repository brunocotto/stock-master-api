using Microsoft.AspNetCore.Mvc;
using StockMaster.Application.UseCases.Suppliers.Register;
using StockMaster.Communication.Requests.Suppliers;
using StockMaster.Communication.Responses;

namespace StockMaster.Api.Controllers;
[Route("api/suppliers")]
[ApiController]
public class SuppliersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Register(
        [FromServices] IRegisterSupplierUseCase useCase,
        [FromBody] RequestRegisterSupplierJson request)
    {
        await useCase.Execute(request);

        return Created();
    }
}
