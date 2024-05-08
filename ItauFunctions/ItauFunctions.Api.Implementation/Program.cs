using ItauFunctions.Api.Implementation.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();
app.Configure();
app.Run();
