using EventSender.Application.Commands;
using EventSender.Application.Extensions;
using EventSender.Infrastructure.Extensions;
using EventSender.WebApi.Extensions;
using EventSender.WebApi.Middlewares;
using MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplication();
builder.Services.ConfigureInfrastructure();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureCorsPolicy();
builder.Services.ConfigureApiBehavior();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateLogger();

var app = builder.Build();

//app.UseWhen(api => api.Request.Path.StartsWithSegments("/api/User/")
//, appBuilder => { app.UseSerilogRequestLogging(); });

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration(builder.Configuration, "SwaggerConfigTest");
}

app.MapPost("/Order/PlaceOrder", async (IMediator mediator, PlaceOrderRequest request) =>
{
    return Results.Ok(await mediator.Send(request));
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseErrorHandler();
app.UseCors();
app.MapControllers();

app.Run();
