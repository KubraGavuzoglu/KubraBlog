using KubraBlog2.Data;
using KubraBlog2.Data.Abstract;
using KubraBlog2.Data.Concrete;
using KubraBlog2.Service.Abstract;
using KubraBlog2.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Server.HttpSys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // veritabaný tablolarýmýzý temsil eden entity framework classý



builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
//builder.Services.AddSingleton<IPostService, PostService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x=>
{
    x.LoginPath = "/Admin/Login";
    x.AccessDeniedPath= "/AccessDenied";
    x.LogoutPath = "/Admin/Login/Logout";
    x.Cookie.Name = "Administrator";
    x.Cookie.MaxAge = TimeSpan.FromMinutes(5);

}
    
    
    );



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

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
