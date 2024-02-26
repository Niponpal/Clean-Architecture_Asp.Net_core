using CleanArchitcure.Application;
using CleanArchitcure.Application.RepositoryServices;
using CleanArchitcure.Infrastructure.DataBase;
using CleanArchitcure.WebApp;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddAutoMapper(x =>
{
    x.AddMaps(typeof(ICore).Assembly);
});
builder.Services.AddTransient<IEmployeeRepositoryServices, EmployeeRepositoryServices>();
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
