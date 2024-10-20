using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBattleLibrary.Services.Errors;

public class UsernameTakenException : Exception
{
    public UsernameTakenException(string username)
        : base($"An account with name '{ username }' already exists. Please select a new name.") { }
}
