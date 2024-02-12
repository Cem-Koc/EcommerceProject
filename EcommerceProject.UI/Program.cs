using EcommerceProject.BLL.DependencyResolvers;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
	.AddNToastNotifyToastr(new ToastrOptions()
	{
		PositionClass = ToastPositions.TopRight,
		TimeOut = 3000
	});

builder.Services.AddIdentityService();
builder.Services.AddDbContextService();
builder.Services.AddRepositoryManagerServices();

builder.Services.AddDistributedMemoryCache();
builder.Services.ConfigureApplicationCookie(configure =>
{
	configure.LoginPath = new PathString("/Admin/Auth/Login");
	configure.LogoutPath = new PathString("/Admin/Auth/Logout");
	configure.Cookie = new CookieBuilder
	{
		Name = "EcommerceProject",
		HttpOnly = true,
		SameSite = SameSiteMode.Strict,
		SecurePolicy = CookieSecurePolicy.SameAsRequest
	};
	configure.SlidingExpiration = true;
	configure.ExpireTimeSpan = TimeSpan.FromDays(7);
	configure.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});
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
app.UseNToastNotify();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
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
