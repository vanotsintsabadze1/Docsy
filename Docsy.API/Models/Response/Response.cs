namespace Docsy.API.Models.Response;

public record Response(string Message, Dictionary<string, string[]>? Errors = null);

public record Response<T>(T Data);