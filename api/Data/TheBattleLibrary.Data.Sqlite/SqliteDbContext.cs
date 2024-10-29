using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Data;

public class SqliteDbContext : DbContext, IApplicationDbContext
{
    public DbSet<UserAccount> Users { get; set; }
    public DbSet<BattleList> BattleLists { get; set; }
    public DbSet<Selection> Selections { get; set; }

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

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SqliteDbContext>
{
    public SqliteDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqliteDbContext>(); 
        optionsBuilder.UseSqlite("Data Source=your_database.db;"); 
        return new SqliteDbContext(optionsBuilder.Options);
    }
}