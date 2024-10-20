using Microsoft.AspNetCore.Mvc;
using StockMaster.Application.UseCases.Categories.GetById;
using StockMaster.Application.UseCases.Categories.Register;
using StockMaster.Communication.Requests.Categories;
using StockMaster.Communication.Responses.Categories;
using StockMaster.Communication.Responses.Exceptions;

namespace StockMaster.Api.Controllers;
[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Register(
        [FromServices] IRegisterCategoryUseCase useCase,
        [FromBody] RequestRegisterCategoryJson request)
    {
        await useCase.Execute(request);

        return Created();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseCategoryJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetCategoryByIdUseCase useCase,
        [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);

    }
}
