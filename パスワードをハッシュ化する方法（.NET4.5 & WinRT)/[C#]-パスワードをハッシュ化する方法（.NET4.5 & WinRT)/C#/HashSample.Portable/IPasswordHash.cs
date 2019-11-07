using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSample.Portable
{
    public interface IPasswordHash
    {
        string GetHashData(string salt, int stretchCount, string password);
    }
}
