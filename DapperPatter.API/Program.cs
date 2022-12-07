using DapperPatter.API.Database;
using DapperPatter.API.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configurationManager = builder.Configuration;
var databaseSection = configurationManager.GetSection("DatabaseName");
var databaseConnection = databaseSection.Value;
// Add services to the container.

builder.Services.AddControllers();
// builder.serviceHost.ConfigureServices((hc, sc) => 
// {
// 	sc.AddDbContext<DiagnosticDbContext>(db => 
//         db.UseSqlServer(hc.Configuration.GetConnectionString("DatabaseName"), 
//         options => options.EnableRetryOnFailure(5))
//     );
// });
// builder.Services.AddSingleton(new DatabaseConfig { Name = Configuration["DatabaseName"] });

builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
builder.Services.AddSingleton<IProductProvider, ProductProvider>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
// builder.ServiceProvider.GetService<IDatabaseBootstrap>().Setup();
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

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});



app.MapControllers();

app.Run();

