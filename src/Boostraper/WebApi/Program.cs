
var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddCatalogModule(builder.Configuration);
builder.Services.AddBasketModule();
builder.Services.AddOrderingModule();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCatalogModule();
app.UseBasketModule();
app.UseOrderingModule();

app.MapGet("/", () => "Hello World!");

app.Run();
