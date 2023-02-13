using Microsoft.Extensions.Configuration;
using ProdutosApi.Infrastructure.Cache;
using ProdutosApi.Infrastructure.CrossCutting.Model;
using ProdutosApi.Infrastructure.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.Configure<AppSettings>(configuration);

builder.Services.RegisterServicesInjection();

builder.Services.UseCache(configuration);

//builder.Services.AddValidatorsFromAssemblyContaining<ProdutoValidator>();

builder.Services.AddControllers();
//.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<ProdutoValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
