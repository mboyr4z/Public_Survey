using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Survey.Benimkiler;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        private static Task userM;
        private static Task roleM;

        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {

            // app genişletme PROGRAM.CS TEKİ
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();

            // IOS gibi bir işlem oldu

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            // miggration aldıktan sorna dotnet ef databas drop ifadesi kullanmamıza gerek yok
        }

        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
            });
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {

            p.f("admin ayarlanıyorr");
            // UserManager kulanıcı kaydı için
            UserManager<IdentityUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            // RoleManager kullanıcıya rol verebilmek için
            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();


            const string adminUser = "Admin";
            const string adminPassword = "admin123.";
            IdentityUser user = await userManager.FindByNameAsync(adminUser);

            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "admin@samsun.edu.tr",
                    PhoneNumber = "05425896434",
                    UserName = adminUser,
                };

                var result = await userManager.CreateAsync(user, adminPassword);

                if (!result.Succeeded)
                {
                    throw new Exception("Admin user could not created.");
                }

                // tüm rolleri admine atayabilmek için
                var roleResult = await userManager.AddToRolesAsync(user,
                    new List<string> { "Admin" }
                );

                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for admin.");
                }
            }

         
            user = await userManager.FindByNameAsync("Boss");

            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "Boss@samsun.edu.tr",
                    PhoneNumber = "1241245343",
                    UserName = "Boss",
                };

                var result = await userManager.CreateAsync(user, "Boss123.");

                if (!result.Succeeded)
                {
                    throw new Exception("Boss user could not created.");
                }

                // tüm rolleri admine atayabilmek için
                var roleResult = await userManager.AddToRolesAsync(user,
                    new List<string> { "Boss" }
                );

                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for Boss.");
                }
            }


            user = await userManager.FindByNameAsync("Author");

            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "Author@samsun.edu.tr",
                    PhoneNumber = "1252357454",
                    UserName = "Author",
                };

                var result = await userManager.CreateAsync(user, "Author123.");

                if (!result.Succeeded)
                {
                    throw new Exception("Author user could not created.");
                }

                // tüm rolleri admine atayabilmek için
                var roleResult = await userManager.AddToRolesAsync(user,
                    new List<string> { "Author" }
                );

                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for Author.");
                }
            }


            user = await userManager.FindByNameAsync("Commentator");

            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "Commentator@samsun.edu.tr",
                    PhoneNumber = "25336786554",
                    UserName = "Commentator",
                };

                var result = await userManager.CreateAsync(user, "Commentator123.");

                if (!result.Succeeded)
                {
                    throw new Exception("Commentator user could not created.");
                }

                // tüm rolleri admine atayabilmek için
                var roleResult = await userManager.AddToRolesAsync(user,
                    new List<string> { "Commentator" }
                );

                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for Commentator.");
                }
            }




        }





    }
}