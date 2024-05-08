using StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddControllersWithViews();         // controllers ve views klasörü için
builder.Services.AddRazorPages();       // razor pageler için

builder.Services.ConfigureDbContext(builder.Configuration);     // extension yazdık
builder.Services.ConfigureSession();

builder.Services.ConfigureIdentity();   // identity eklendi

builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureRouting();
builder.Services.ConfigureApplicationCookie();


var app = builder.Build();

app.UseStaticFiles();       // wwwroot klasöürün kullanılabilir hale getir
app.UseSession();

app.UseHttpsRedirection();      // yönlendirme https üzernden olcak, redirect için gerekli
app.UseRouting(); // yönlendirme için gerekli

app.UseAuthentication();   // önce oturum, sonra yetkilendirme 
app.UseAuthorization();  // oturum açma ve yetkilendirme, bunlarda routing ile endpoint arasında olmalı yoksa çalışmaz

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute("default", "{controller=Login}/{action=Index}/{id?}"); // name and pattern

    endpoints.MapRazorPages();

    endpoints.MapControllers();     // api endpoint ayarı ekendi
});

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();
app.Run();