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