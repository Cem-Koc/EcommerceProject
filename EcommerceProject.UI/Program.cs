using EcommerceProject.BLL.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentityService();
builder.Services.AddDbContextService();
builder.Services.AddRepositoryManagerServices();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(x =>
{
	x.IdleTimeout = TimeSpan.FromMinutes(2);
	x.Cookie.HttpOnly = true;
	x.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
		name: "Admin",
		areaName: "Admin",
		pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapDefaultControllerRoute();
});

app.Run();
