using Microsoft.AspNetCore.Mvc;
using StockMaster.Application.UseCases.Suppliers.GetById;
using StockMaster.Application.UseCases.Suppliers.Register;
using StockMaster.Communication.Requests.Suppliers;
using StockMaster.Communication.Responses.Exceptions;
using StockMaster.Communication.Responses.Suppliers;

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

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseSupplierJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetSupplierByIdUseCase useCase,
        [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);

    }
}
