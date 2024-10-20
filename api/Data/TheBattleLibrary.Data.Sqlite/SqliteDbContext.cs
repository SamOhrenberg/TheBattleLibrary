using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Data;

public class SqliteDbContext : DbContext, IApplicationDbContext
{
    public DbSet<UserAccount> Users { get; set; }

    public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
    {
    }
}
