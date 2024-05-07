using ErrorHandlerandAuthetication.DBContexts;
using ErrorHandlerandAuthetication.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    builder.Services.AddTransient<GlobalExceptionHandleMiddleware>();
    builder.Services.AddSwaggerGen();

    // Nlog
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // DBContext
    builder.Services.AddDbContext<ProjectContext>(ob =>
    {
        ob.UseSqlServer(builder.Configuration.GetConnectionString("MyConnStr"));
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    else
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.UseMiddleware<GlobalExceptionHandleMiddleware>();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}");

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex.Message);
}
