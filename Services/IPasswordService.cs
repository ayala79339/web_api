using System;
using System.Collections.Generic;
using System.Text;
//The Zxcvbn package is referenced only in web_api.csproj: which project needs it so that PasswordService compiles?
using Zxcvbn;
namespace Services
{
    public interface IPasswordService
    { 
        int GetStrength(string password);
    }

    public class PasswordService : IPasswordService
        {
            public int GetStrength(string password)
            {
                if (password == null)
                    return -1;
                return Zxcvbn.Core.EvaluatePassword(password).Score;
            }
        }
    }
}
//Which brace is this? It closes nothing: remove it, or check which class or namespace is missing its opening brace
}
