using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBattleLibrary.Services.Errors;

public class InvalidPasswordException : Exception
{
    public override string Message
    {
        get
        {
            return $"There are { Errors.Count } problems with the given password. Please check the Errors for details.";
        }
    }
    
    public List<string> Errors { get; init; } = [];

    public InvalidPasswordException()
    {

    }
}
