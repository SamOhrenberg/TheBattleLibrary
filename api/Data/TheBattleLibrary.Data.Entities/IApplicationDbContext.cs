using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TheBattleLibrary.Data.Entities;

public interface IApplicationDbContext
{
    DbSet<UserAccount> Users { get; set; }
    
    DbSet<BattleList> BattleLists { get; set; } 
    DbSet<Selection> Selections { get; set; }
    
    DbSet<UserToken> UserTokens { get; set; }
    
    DatabaseFacade Database { get; }

    int SaveChanges();
}
