using HashSample.Portable;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace HashSample
{
    public class PasswordHash : PasswordHashBase
    {
        protected override string ComputeHash(string input)
        {
            var provider = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha256);
            var buffer = CryptographicBuffer.ConvertStringToBinary(input, BinaryStringEncoding.Utf8);
            var hashedBuffer = provider.HashData(buffer);
            return CryptographicBuffer.EncodeToBase64String(hashedBuffer);
        }
    }
}
