using Docsy.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Docsy.API.Extensions;

public static class ResponseResultExtensions
{
    public static IActionResult ToActionResult<T>(this ResponseResult<T> responseResult)
    {
        return new ObjectResult(responseResult.ResponseType) { StatusCode = responseResult.StatusCode };
    }
}