namespace TheBattleLibrary.Data.Entities;

public class Selection
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public required int Quantity { get; init; } 

    // Parent list or selection it belongs to
    public Guid? ParentListId { get; set; } 
    public BattleList? ParentList { get; set; } 
    
    public Guid? ParentSelectionId { get; set; } 
    public Selection? ParentSelection { get; set; } 
    
    public ICollection<Selection> ChildSelections { get; init; } = new List<Selection>();
}