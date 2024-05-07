

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ServiceExtension
    {

        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            /* services.AddScoped<IServiceManager, ServiceManager>();
             services.AddScoped<IProductService, ProductManager>();
             services.AddScoped<ICategoryService, CategoryManager>();
             services.AddScoped<IOrderService, OrderManager>();
             services.AddScoped<IAuthService, AuthManager>();*/

        }

        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });
        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false; // sonuna / ifadesi eklensin
            });

        }


        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            /* services.AddScoped<IRepositoryManager, RepositoryManager>();        // IOS için  yapılıyor bu
             services.AddScoped<IProductRepository, ProductRepository>();
             services.AddScoped<ICategoryRepsitory, CategoryRepository>();
             services.AddScoped<IOrderRepository, OrderRepository>();*/
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;  //  e-mailnii onaylayacakmıyız
                options.User.RequireUniqueEmail = true;      // bir kullanıcı bir epostayla ilişkilendirilsin
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<RepositoryContext>();
        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            // builder.Serivec e karşılık geliyor services.
            services.AddDistributedMemoryCache();       // ön bellek, sunucuda tutulur, sunucu kapandıgında gider
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";  // session adlandırma
                options.IdleTimeout = TimeSpan.FromMinutes(10);     // 10 dakika tut

            });      // session için
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //  services.AddScoped<Cart>(c => SessionCart.GetCart(c));
        }

        public static void ConfigureDbContext(this IServiceCollection services,
        IConfiguration configuration)
        {

            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("sqlconnection"),
                b => b.MigrationsAssembly("Survey"));     // appsetting içinde verdiğim değeri static        

                options.EnableSensitiveDataLogging(true);   // Hassas bilgileri loglama

            }); // kullanacağım bir db context servisini ekliyoruz, repo context classı için
        }


    }
}