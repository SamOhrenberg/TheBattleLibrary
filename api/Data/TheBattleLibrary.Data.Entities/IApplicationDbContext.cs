using Microsoft.EntityFrameworkCore;
using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Data
{
    public interface IApplicationDbContext
    {
        DbSet<UserAccount> Users { get; set; }
    }
}