using DepartmentsRefbook.DataAccess.General;
using DepartmentsRefbook.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(config =>
{
    var dataFolderPath = Path.Combine(builder.Environment.ContentRootPath, "Data");
    var connectionString = builder.Configuration
        .GetConnectionString("Default")
        .Replace("{DataDirectory}", dataFolderPath);
    config.UseSqlServer(connectionString, config => config.MigrationsAssembly("DepartmentsRefbook.DataAccess"));
});
builder.Services
    .AddTransient<ICompanyRepository, CompanyRepository>()
    .AddTransient<IDepartmentRepository, DepartmentRepository>()
    .AddTransient<IBranchRepository, BranchRepository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
}

app.Run();
