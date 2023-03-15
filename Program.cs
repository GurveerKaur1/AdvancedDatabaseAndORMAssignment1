using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdvancedDatabaseAndORMAssignment1.Data;
using AdvancedDatabaseAndORMAssignment1.Models;
using AdvancedDatabaseAndORMAssignment1.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdvancedDatabaseAndORMAssignment1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdvancedDatabaseAndORMAssignment1Context") ?? throw new InvalidOperationException("Connection string 'AdvancedDatabaseAndORMAssignment1Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;
    await AdvancedDatabaseAndORMAssignment1.Data.SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
