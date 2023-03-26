using api_at_shop.Auth;
using api_at_shop.Repository;
using api_at_shop.Services;
using api_at_shop.Services.AuthServices;
using api_at_shop.Services.AuthServices.Common;
using api_at_shop.Services.common.EmailServices;
using api_at_shop.Services.EmailServices;
using api_at_shop.Services.printify;
using api_at_shop.Services.ProductServices;
using api_at_shop.Services.ProductServices.Common;
using Microsoft.AspNetCore.Authentication;
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
builder.Services.AddSingleton<IBasicAuthService, BasicAuthService>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddScoped<ITranslationService, TranslationService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .WithOrigins("*")
            .WithMethods("*")
            .WithHeaders("Authorization");
    });
});

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

