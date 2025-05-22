using Npu.Api;
using Npu.Api.Endpoints;
using Npu.Api.Endpoints.Swagger;
using Npu.Application;
using Npu.Infrastructure;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation(builder.Configuration)
    .AddInfrastructure()
    .AddApplication()
    ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{
    options.SupportNonNullableReferenceTypes();
    options.NonNullableReferenceTypesAsRequired();
}
);

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app
    .RegisterSwaggerEndpoint()
    .RegisterEndpointsFromAssembly()
    ;

app.Run();

[ExcludeFromCodeCoverage]
public partial class Program;