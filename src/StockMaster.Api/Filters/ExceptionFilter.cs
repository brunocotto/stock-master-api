using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StockMaster.Communication.Responses.Exceptions;
using StockMaster.Exception;
using StockMaster.Exception.ExceptionsBase;

namespace StockMaster.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is StockMasterException)
        {
            HandleProjectException(context);

        } else
        {
            ThrowUnknowError(context);
        }

    }

    private void HandleProjectException(ExceptionContext context)

    {
        var cashFlowException = (StockMasterException)context.Exception;

        var errorResponse = new ResponseErrorJson(cashFlowException.GetErrors());
        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
        context.Result = new ObjectResult(errorResponse);

        

    }

    private void ThrowUnknowError(ExceptionContext context) 
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(context.Result);  
    }
}
