using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Data
{
    public interface IApplicationDbContext
    {
        DbSet<UserAccount> Users { get; set; }
        DatabaseFacade Database { get; }

        int SaveChanges();
    }
}