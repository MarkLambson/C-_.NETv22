var builder = WebApplication.CreateBuilder(args);
//services must be located here
builder.Services.AddControllersWithViews();

var app = builder.Build();
//lines 8-10 must be located here
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
