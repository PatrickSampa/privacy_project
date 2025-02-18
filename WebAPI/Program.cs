using CleanArchtecture.Persistence.Context;
using CleanArchtecture.Persistence;
using CleanArchitecture.Application.Services;
using WebAPI.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigPersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.ConfigureCorsPolicy();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

CreateDatabase(app);



app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.UseCors();

app.Run();


static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}