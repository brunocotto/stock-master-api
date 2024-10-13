using Microsoft.AspNetCore.Mvc;
using StockMaster.Application.UseCases.Categories.Register;
using StockMaster.Communication.Requests.Categories;
using StockMaster.Communication.Responses;

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
}
