using BuildingBlocks.Behaviour;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

// Inject Services  in  Container service
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});
var app = builder.Build();

//Configure Http Request Pipepile
app.MapCarter();
app.Run();
