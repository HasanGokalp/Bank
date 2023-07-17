using Bank.Domain.Repositories;
using Bank.Domain.Services;
using Bank.Persistence;
using Bank.Service.Services;
using Bank.Persistence.Contexts.EFCore;
using Bank.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitWork, UnitWork>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddDbContext<BankContext>(s =>
{
    s.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BankApp;Trusted_Connection=True;TrustServerCertificate=True");
});
builder.Services.AddAutoMapper(a =>
{
    a.AddMaps(Assembly.GetExecutingAssembly());
});


var app = builder.Build();

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
