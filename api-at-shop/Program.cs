using api_at_shop.Repository;
using api_at_shop.Services;
using api_at_shop.Services.printify;
using api_at_shop.Services.ProductServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnection"));
});

builder.Services.AddScoped<IProductApiService, PrintifyService>();
builder.Services.AddScoped<ICurrencyService, HnbWebApiService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("at-shop-policy",
        policy =>
        {
            policy.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("at-shop-policy");

app.UseAuthorization();

app.MapControllers();

app.Run();

