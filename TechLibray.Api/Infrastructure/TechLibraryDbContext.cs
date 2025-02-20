using Microsoft.EntityFrameworkCore;
using TechLibray.Api.Domain.Entidades;

namespace TechLibray.Api.Infrastructure;

public class TechLibraryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\skytu\\Downloads\\TechLibraryDb.db");
    }
}
