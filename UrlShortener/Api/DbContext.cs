using Microsoft.EntityFrameworkCore;
using Api.Model;

namespace Api;

public class ApplicationDbContext : DbContext
{
    public DbSet<Url> Url { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}
