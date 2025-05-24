using Microsoft.OpenApi.Models;
using Npu.Api;
using Npu.Api.Endpoints;
using Npu.Api.Endpoints.Swagger;
using Npu.Application;
using Npu.Infrastructure;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SupportNonNullableReferenceTypes();
    options.NonNullableReferenceTypesAsRequired();

    OpenApiSecurityScheme jwtSecurityScheme = new()
    {
        Reference = new OpenApiReference
        {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme
        },

        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Insert Bearer token without 'Bearer' prefix"
    };

    options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    OpenApiSecurityRequirement requirement = new()
    {
        { jwtSecurityScheme, [] }
    };
    options.AddSecurityRequirement(requirement);
}
);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .RegisterSwaggerEndpoint()
    .RegisterEndpointsFromAssembly()
    ;

app.Run();

[ExcludeFromCodeCoverage]
public partial class Program;