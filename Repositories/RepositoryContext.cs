
using System.Reflection;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepositoryContext : IdentityDbContext<IdentityUser>//  DbContext    esski implemention  // bu class vt olarak düşünülecek, modeli tabloya dönüştürmek için db set
{
    public DbSet<Author>? Authors { get; set; }
    public DbSet<Boss> Bosses { get; set; }
    public DbSet<Commentator> Commentators { get; set; }
    public DbSet<Company> Companies { get; set; }

    public DbSet<Chat> Chats { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Follow> Follows { get; set; }

    public DbSet<Like> Likes { get; set; }

    public DbSet<Post> Posts { get; set; }


    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)   // baseye yolla
    {

    }
    // connection string appsettings.json dosyasındadır

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);

    }


}
