using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TheBattleLibrary.Data.Sqlite;

namespace TheBattleLibrary.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SqliteDbContext>
{
    public SqliteDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqliteDbContext>(); 
        optionsBuilder.UseSqlite("Data Source=your_database.db;"); 
        return new SqliteDbContext(optionsBuilder.Options);
    }
}