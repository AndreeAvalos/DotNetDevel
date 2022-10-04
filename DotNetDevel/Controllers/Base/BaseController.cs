using DotNetDevel.Models.Response.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDevel.Controllers.Base;

public class BaseController : ControllerBase
{
    private string ControllerActionName()
    {
        try
        {
            return
                $"Method: {ControllerContext.ActionDescriptor.ControllerName} - Path: {ControllerContext.ActionDescriptor.ActionName}";
        }
        catch
        {

            return "Method: Generic - Path: Error";
        }
    }

    [NonAction]
    protected ObjectResult GetResponse<T>(ResponseSuccess<T> res)
    {
        res.TransactionName = ControllerActionName();
        ObjectResult objectResult = new(res)
        {
            StatusCode = res.StatusCode
        };

        return objectResult;
    }
}