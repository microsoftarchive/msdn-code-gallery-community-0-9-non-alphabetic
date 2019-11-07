using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSample.Portable
{
    public abstract class PasswordHashBase : IPasswordHash
    {
        public string GetHashData(string salt, int stretchCount, string password)
        {
            var hashedSalt = this.ComputeHash(salt);
            var result = password;
            foreach (var _ in Enumerable.Repeat(0, stretchCount))
            {
                result = this.ComputeHash(hashedSalt + result);
            }
            return result;
        }

        protected abstract string ComputeHash(string input);
    }
}
