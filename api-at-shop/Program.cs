using api_at_shop.Services;
using api_at_shop.Services.printify;
using api_at_shop.Services.ProductServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductApiService, PrintifyService>();
builder.Services.AddSingleton<ICurrencyService, HnbWebApiService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var url = builder.Configuration.GetConnectionString("PrintifyApiUrl");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

