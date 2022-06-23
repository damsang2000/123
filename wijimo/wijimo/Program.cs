using wijimo.Model;
using wijimo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wijimo.Data;
using wijimo.Entity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<wijimoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("wijimoContext") ?? throw new InvalidOperationException("Connection string 'wijimoContext' not found.")));

builder.Services.AddSingleton<ICarService, CarService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


//get all car
app.MapGet("/api/cars", (ICarService service) =>
{
    return Results.Ok(service.GetAll());
});

//get id car
app.MapGet("/api/car/{id:int}", (int id, ICarService service) =>
{
    var car = service.Get(id);
    return car;
});
//method map
app.MapMethods("/api/save", new[] { "POST", "PUT" }, (Car car, ICarService service) =>
{
    service.Save(car);
    return Results.Ok();
});

app.Run();
