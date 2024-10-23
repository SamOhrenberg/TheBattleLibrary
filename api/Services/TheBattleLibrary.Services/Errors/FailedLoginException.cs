using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBattleLibrary.Services.Errors;

public class FailedLoginException : Exception
{
    public FailedLoginException(string message) : base(message) { }

    public static FailedLoginException IncorrectUsernameOrPassword = new("The provided username or password is incorrect");
}
