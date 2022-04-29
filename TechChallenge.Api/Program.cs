using TechChallenge.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddBuilderApplicationServices();
builder.RegisterModules();

var app = builder.Build();
app.ConfigureApplication();
app.MapEndpoints();

app.Run();