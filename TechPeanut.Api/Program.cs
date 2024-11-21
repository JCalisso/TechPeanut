using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using Serilog;

using TechPeanut.Api.Models.Context;
using System.Net.Http.Headers;
using TechPeanut.Api.Business;
using TechPeanut.Api.Business.Implementations;
using TechPeanut.Api.Repository.Generic;
using System.IO;
using TechPeanut.Api.Hypermedia.Filters;
using TechPeanut.Api.Hypermedia.Enricher;
using TechPeanut.Api.Repository.Login.Interfaces;
using TechPeanut.Api.Repository.Login;

var builder = WebApplication.CreateBuilder(args);

var appName = "TechPeanut";
var appVersion = "v1";
var appDescription = $"REST API of '{appName}'";

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var connection = config["db:connection"];
builder.Services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection));


IWebHostEnvironment environment = builder.Environment;

builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;

    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/xml"));

    options.FormatterMappings.SetMediaTypeMappingForFormat("json", Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json"));

}).AddXmlSerializerFormatters();

builder.Services.AddRouting(options => options.LowercaseUrls = true); //configura as letras minúsculas na URL

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PessoasEnricher());
filterOptions.ContentResponseEnricherList.Add(new LoginEnricher());

builder.Services.AddSingleton(filterOptions);

//Verioning API
builder.Services.AddApiVersioning();
builder.Services.AddMvc();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(appVersion,
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = appName,
            Version = appVersion,
            Description = appDescription,
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Jean Calisso",
                Url = new Uri("https://github.com/JCalisso")
            }
        });
});

builder.Services.AddScoped<IPessoaBusiness, PessoasBusinessImplementation>();
builder.Services.AddScoped<ITelefoneBusiness, TelefoneBusinessImplementation>();
builder.Services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();
builder.Services.AddScoped<IEnderecosBusiness, EnderecoBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(ILoginRepository<>), typeof(LoginRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{appName} - {appVersion}");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);


app.Run();
