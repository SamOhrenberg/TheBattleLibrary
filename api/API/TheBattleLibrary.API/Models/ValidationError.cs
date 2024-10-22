namespace TheBattleLibrary.API.Models;

public class ValidationError : Error
{
   public IEnumerable<string> Errors { get; init; }
}
