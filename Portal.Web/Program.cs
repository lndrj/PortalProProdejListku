using Microsoft.EntityFrameworkCore;
using Portal.Application.Abstraction;
using Portal.Application.Implementation;
using Portal.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Databaze
string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.34");
builder.Services.AddDbContext<PortalDBContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));


//Services databaze - admin
builder.Services.AddScoped<IAkceAdminService, AkceAdminService>();
builder.Services.AddScoped<IAccountsAdminService, AccountsAdminService>();
builder.Services.AddScoped<IDiscussionAdminService, DiscussionAdminService>();
builder.Services.AddScoped<IRequestsAdminService, RequestsAdminService>();
builder.Services.AddScoped<IHomeService, HomeService>();


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
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
