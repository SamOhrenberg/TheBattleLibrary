namespace TheBattleLibrary.API.Models;

public class ValidationError : Error
{
   public required IEnumerable<string> Errors { get; init; }
}
