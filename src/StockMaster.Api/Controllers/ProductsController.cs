using Microsoft.AspNetCore.Mvc;
using StockMaster.Application.UseCases.Products.Register;
using StockMaster.Communication.Requests.Products;
using StockMaster.Communication.Responses.Exceptions;

namespace StockMaster.Api.Controllers;
[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Register(
        [FromServices] IRegisterProductUseCase useCase,
        [FromBody] RequestRegisterProductJson request)
    {
        await useCase.Execute(request);

        return Created();
    }
}
