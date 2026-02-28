using DevNote.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevNote.API.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Entry> Entries { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}