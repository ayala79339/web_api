using System;
using System.Collections.Generic;
using System.Text;
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
}
