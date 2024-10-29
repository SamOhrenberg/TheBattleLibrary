using Microsoft.EntityFrameworkCore;
using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Data.Tests;

public class ApplicationDbContextTests
{
    [Fact]
    public void CanAddUserAccount()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "CanAddUserAccount")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            var user = new UserAccount(Guid.NewGuid(),"testuser", "hashedpassword");
            context.Users.Add(user);
            context.SaveChanges();
        }

        using (var context = new ApplicationDbContext(options))
        {
            Assert.Equal(1, context.Users.Count());
            Assert.Equal("testuser", context.Users.Single().Username);
        }
    }

    [Fact]
    public void CanAddBattleListWithSelections()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "CanAddBattleListWithSelections")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            var battleList = new BattleList { Id = Guid.NewGuid(), Name = "Test Battle List" };
            var selection = new Selection { Id = Guid.NewGuid(), ParentListId = battleList.Id, Name = "Test Selection", Quantity = 1 };
            battleList.Selections.Add(selection);
            context.BattleLists.Add(battleList);
            context.SaveChanges();
        }

        using (var context = new ApplicationDbContext(options))
        {
            var battleList = context.BattleLists.Include(bl => bl.Selections).Single();
            Assert.Single(battleList.Selections);
            Assert.Equal("Test Selection", battleList.Selections.Single().Name);
        }
    }

    [Fact]
    public void CanAddSelectionWithChildSelections()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "CanAddSelectionWithChildSelections")
            .Options;

        var parentGuid = Guid.NewGuid();
        using (var context = new ApplicationDbContext(options))
        {
            var parentSelection = new Selection { Id = parentGuid, Name = "Parent Selection", Quantity = 1};
            var childSelection = new Selection { Id = Guid.NewGuid(), ParentSelectionId = parentSelection.Id, Name = "Child Selection", Quantity = 1 };
            parentSelection.ChildSelections.Add(childSelection);
            context.Selections.Add(parentSelection);
            context.SaveChanges();
        }

        using (var context = new ApplicationDbContext(options))
        {
            var parentSelection = context.Selections.Include(s => s.ChildSelections).Single(s => s.Id == parentGuid);
            Assert.Single(parentSelection.ChildSelections);
            Assert.Equal("Child Selection", parentSelection.ChildSelections.Single().Name);
        }
    }
}