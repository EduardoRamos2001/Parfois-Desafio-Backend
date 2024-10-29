using Parfois.API.Data;
using Parfois.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Parfois");
builder.Services.AddSqlite<ParfoisContext>(connString);

var app = builder.Build();

app.MapItemsEndpoints();
app.MapPedidosEndpoints();
app.MapStatusEndpoints();

await app.MigrateDbAsync();

app.Run();
