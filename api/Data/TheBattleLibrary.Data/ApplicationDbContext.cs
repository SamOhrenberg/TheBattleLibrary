using Microsoft.EntityFrameworkCore;
using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<UserAccount> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
