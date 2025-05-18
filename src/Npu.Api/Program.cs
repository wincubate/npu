using Microsoft.OpenApi.Models;
using Npu.Api;
using Npu.Api.Endpoints.Swagger;
using Npu.Api.Endpoints.Upload;
using Npu.Application;
using Npu.Infrastructure;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication()
    .AddInfrastructure()
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
    .RegisterSwaggerEndpointMappings()
    .RegisterUploadEndpointMappings()
    ;

app.Run();

[ExcludeFromCodeCoverage]
public partial class Program;