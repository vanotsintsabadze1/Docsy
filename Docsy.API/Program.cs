using Scalar.AspNetCore;
using Docsy.Persistence;
using Docsy.API;
using Docsy.API.Interfaces.PasswordUtility;
using Docsy.API.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Docsy.API.Constants.Options;
using Docsy.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureAuthentication();

builder.Services.AddScoped<IPasswordUtility, PasswordUtility>();

builder.Services.Configure<AuthenticationOptions>(builder.Configuration.GetSection(nameof(AuthenticationOptions)));

builder.Services.RegisterPersistenceServices(builder.Configuration);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
    await Seed.Initialize(app.Services);

app.Run();