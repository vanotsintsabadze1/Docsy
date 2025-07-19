namespace Docsy.API.Interfaces.Response;

public interface IFailedResponse
{
    string Message { get; }
    Dictionary<string, string[]>? Errors { get; }
}

public interface ISuccessResponse<T>
{
    T Data { get; }
}