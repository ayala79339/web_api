using System;
using System.Collections.Generic;
using System.Text;
using Zxcvbn;
//Does the Services project need the zxcvbn-core package too? It is referenced only in web_api.csproj, and this file uses Zxcvbn
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
//The build fails here (CS1022): the namespace already closes on the line above, so what do these two } close?
}
}
