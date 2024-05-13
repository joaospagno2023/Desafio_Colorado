using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Server.Business.DesafioColorado.InterfaceCliente;
using Server.Business.DesafioColorado.InterfaceGenerica;
using Server.Business.DesafioColorado.InterfaceTipoTelefone;
using Server.Business.DesafioColorado.ITelefone;
using Server.DataAcess;
using Server.DataAcess.DesafioColorado.ClienteRepositorio;
using Server.DataAcess.DesafioColorado.Config;
using Server.DataAcess.DesafioColorado.RepositorioGenerico;
using Server.DataAcess.DesafioColorado.Telefone;
using Server.DataAcess.DesafioColorado.TipoTelefoneRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<AppDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<ICliente, RepositorioCliente>();
builder.Services.AddSingleton<ITipoTelefone, RepositorioTipoTelefone>();
builder.Services.AddSingleton<ITelefone, RepositorioTelefone>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsPolicy",
//        builder => builder
//            .AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .WithMethods("GET", "PUT", "DELETE", "POST", "PATCH") //not really necessary when AllowAnyMethods is used.
//    );
//});


var app = builder.Build();

var host = new WebHostBuilder()
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseIISIntegration()
    .Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

//app.UseRouting();
//app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
