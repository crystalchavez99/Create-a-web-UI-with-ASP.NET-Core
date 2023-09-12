using ContosoPizza.Data;
using ContosoPizza.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseSqlite("Data Source=ContosoPizza.db"));
    /*
    This code registers the PizzaService class with the dependency
    injection container. The AddScoped method indicates that a new
    PizzaService object should be created for each HTTP request.
    Now the PizzaService can be injected into any Razor page.
    */
builder.Services.AddScoped<PizzaService>();


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

app.Run();
