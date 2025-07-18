using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger(opt => opt.RouteTemplate = "/openapi/{documentName}.json");
app.MapScalarApiReference(opt =>
    {
        opt.HideModels = true;
        opt.DocumentDownloadType = DocumentDownloadType.None;
        opt.WithTitle("Docsy API Documentation");
    }
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
