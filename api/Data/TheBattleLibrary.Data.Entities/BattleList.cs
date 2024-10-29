namespace TheBattleLibrary.Data.Entities;

public class BattleList
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Faction { get; set; } = string.Empty;
    public ICollection<Selection> Selections { get; init; } = new List<Selection>();
}