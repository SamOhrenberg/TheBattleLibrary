using System.ComponentModel.DataAnnotations;

namespace TheBattleLibrary.Data.Entities;

public class UserToken
{
    [Key]
    public required string Token { get; set; }
    public required DateTime ExpiresAt { get; init; }
    public bool IsRevoked { get; set; } = false;
}