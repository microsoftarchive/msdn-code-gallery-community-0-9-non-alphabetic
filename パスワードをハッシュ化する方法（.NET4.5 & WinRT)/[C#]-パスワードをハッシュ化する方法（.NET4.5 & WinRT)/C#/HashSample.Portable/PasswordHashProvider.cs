using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HashSample.Portable
{
    public static class PasswordHashProvider
    {
        static PasswordHashProvider()
        {
            var type = typeof(PasswordHashProvider).GetTypeInfo();
            var fullName = "HashSample.PasswordHash, " +
                new AssemblyName(type.Assembly.FullName)
                {
                    Name = "HashSample.Platform"
                };
            var passwordHashType = Type.GetType(fullName);
            if (passwordHashType == null)
            {
                throw new NotSupportedException("HashSample.Platform.dllが見つかりません");
            }

            PasswordHash = (IPasswordHash)Activator.CreateInstance(passwordHashType);
        }

        public static IPasswordHash PasswordHash { get; private set; }
    }
}
