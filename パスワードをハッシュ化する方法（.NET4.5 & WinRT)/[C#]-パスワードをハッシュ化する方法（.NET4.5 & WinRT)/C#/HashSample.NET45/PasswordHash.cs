using HashSample.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashSample
{
    public class PasswordHash : PasswordHashBase
    {
        protected override string ComputeHash(string input)
        {
            return System.Convert.ToBase64String(
                SHA256Managed.Create().ComputeHash(Encoding.UTF8.GetBytes(input)));
        }
    }
}
