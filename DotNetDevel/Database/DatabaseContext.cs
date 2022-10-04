using DotNetDevel.Database.Context.Base;
using DotNetDevel.Entities.Config;
using Microsoft.EntityFrameworkCore;

namespace DotNetDevel.Database;

public class DatabaseContext : BaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfig());
    }
}