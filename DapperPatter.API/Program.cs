using DapperPatter.API.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
services.AddSingleton(new DatabaseConfig { Name = Configuration["DatabaseName"] });
services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
services.AddSingleton<IProductProvider, ProductProvider>();
services.AddSingleton<IProductRepository, ProductRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// void Configure(IApplicationBuilder app, 
//             IWebHostEnvironment env,
//             IServiceProvider serviceProvider)
// {
//     if (env.IsDevelopment())
//     {
//         app.UseDeveloperExceptionPage();
//     }
 
//     app.UseHttpsRedirection();
 
//     app.UseRouting();
 
//     app.UseAuthorization();
 
    // app.UseEndpoints(endpoints =>
    // {
    //     endpoints.MapControllers();
    // });
 
//     serviceProvider.GetService<IDatabaseBootstrap>().Setup();
// }

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

serviceProvider.GetService<IDatabaseBootstrap>().Setup();

app.MapControllers();

app.Run();

