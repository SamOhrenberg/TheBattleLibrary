using Microsoft.EntityFrameworkCore;
using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Data.Sqlite;

public class SqliteDbContext : DbContext, IApplicationDbContext
{
    public DbSet<UserAccount> Users { get; set; }
    public DbSet<BattleList> BattleLists { get; set; }
    public DbSet<Selection> Selections { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }

    public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BattleList>()
            .HasMany(l => l.Selections)
            .WithOne(s => s.ParentList)
            .HasForeignKey(s => s.ParentListId); 
        
        modelBuilder.Entity<Selection>()
            .HasMany(s => s.ChildSelections)
            .WithOne(s => s.ParentSelection)
            .HasForeignKey(s => s.ParentSelectionId); 
        
        base.OnModelCreating(modelBuilder);
    }

}