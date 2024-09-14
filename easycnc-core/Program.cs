using easycnc_core.Areas.System.Interface;
using easycnc_core.Areas.System.Service;
using easycnc_core.Data;
using easycnc_core.Middleware;
using easycnc_core.Workflow;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Persistence.EntityFramework.Interfaces;
using WorkflowCore.Persistence.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
);


builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IDeptService, DeptService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IPermissionService, PermissionService>();



builder.Services.AddWorkflow(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("Postgresql"),true,true));


var app = builder.Build();


//数据库自动迁移
using var myScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope();
var dbContext = myScope.ServiceProvider.GetRequiredService<AppDbContext>();
if (dbContext.Database.GetPendingMigrations().Any())
{
    dbContext.Database.Migrate();
    
}
if (!dbContext.Depts.Any())
{
    Console.WriteLine("部门表没有数据any");
}

//workflow core服务开启
var host = app.Services.GetService<IWorkflowHost>();
if (host != null)
{
    host.RegisterWorkflow<HelloWorldWorkflow>();
    host.RegisterWorkflow<AddNumberWorkflow,MyDataClass>();
    host.RegisterWorkflow<HumanWorkflow>();
    host.Start();
   
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//app.UseException();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
    name: "system",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "auth",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
