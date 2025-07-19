using Docsy.API.Interfaces.Response;

namespace Docsy.API.Utilities;

public class ResponseBuilder
{
    public static ResponseResult<IFailedResponse> Fail(string message, int statusCode)
    {
        ValidateFailedResponseStatusCode(statusCode);
        return new ResponseResult<IFailedResponse>(new ResponseModel(message), statusCode);
    }

    public static ResponseResult<IFailedResponse> Fail(string message, int statusCode, Dictionary<string, string[]> errors)
    {
        ValidateFailedResponseStatusCode(statusCode);
        return new ResponseResult<IFailedResponse>(new ResponseModel(message, errors), statusCode);
    }

    public static ResponseResult<ISuccessResponse<T>> Ok<T>(T data) =>
        new(new ResponseModel<T>(data), StatusCodes.Status200OK);

    public static ResponseResult<ISuccessResponse<T>> Ok<T>(T data, int statusCode)
    {
        if (statusCode < StatusCodes.Status200OK || statusCode >= StatusCodes.Status300MultipleChoices)
            throw new ArgumentOutOfRangeException(nameof(statusCode), "Status code must be in the range of 200 to 299 for successful responses.");

        return new ResponseResult<ISuccessResponse<T>>(new ResponseModel<T>(data), statusCode);
    }

    private record ResponseModel(string Message, Dictionary<string, string[]>? Errors = null) : IFailedResponse;
    private record ResponseModel<T>(T Data) : ISuccessResponse<T>;

    private static void ValidateFailedResponseStatusCode(int statusCode)
    {
        if (statusCode < StatusCodes.Status400BadRequest || statusCode > StatusCodes.Status499ClientClosedRequest)
            throw new ArgumentOutOfRangeException(nameof(statusCode), "Status code must be in the range of 400 to 599 for failed responses.");
    }
}

public record ResponseResult<T>(T ResponseType, int StatusCode);