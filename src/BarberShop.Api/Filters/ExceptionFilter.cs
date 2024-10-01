using BarberShop.Communication.Responses;
using BarberShop.Exception;
using BarberShop.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberShop.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is BarberShopException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnkowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var barberShopException = (BarberShopException) context.Exception;
        var errorResponse = new ResponseErrorJson(barberShopException.GetErrors());


        context.HttpContext.Response.StatusCode = barberShopException.StatusCode;
        context.Result = new ObjectResult(errorResponse);

    }

    private void ThrowUnkowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);

    }
}
