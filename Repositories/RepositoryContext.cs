
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepositoryContext : IdentityDbContext<IdentityUser>//  DbContext    esski implemention  // bu class vt olarak düşünülecek, modeli tabloya dönüştürmek için db set
{
    /*public DbSet<Product>? Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }*/

    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)   // baseye yolla
    {

    }
    // connection string appsettings.json dosyasındadır

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


}
