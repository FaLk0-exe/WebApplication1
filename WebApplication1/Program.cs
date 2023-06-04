using Pharm.DLL.DI;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", config =>
{
    config.Cookie.Name = "User.Cookie";
    config.LoginPath = "/Home/Authenticate";
});
builder.Services.AddControllersWithViews();
builder.Services.AddDependencies();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
