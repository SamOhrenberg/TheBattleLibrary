using Microsoft.EntityFrameworkCore;
using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<UserAccount> Users { get; set; }
    public DbSet<BattleList> BattleLists { get; set; }
    public DbSet<Selection> Selections { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

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
