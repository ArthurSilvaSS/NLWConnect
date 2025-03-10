﻿using Microsoft.EntityFrameworkCore;
using TechLibray.Api.Domain.Entidades;

namespace TechLibray.Api.Infrastructure.DataAccess;

public class TechLibraryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=D:\\Estudo\\C#\\NWLConnect\\TechLibraryDb.db");
    }
}
