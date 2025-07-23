using Docsy.API.Constants.Options;
using Docsy.API.Interfaces.PasswordUtility;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Docsy.API.Utilities;

public class PasswordUtility : IPasswordUtility
{
    public (string Hash, string Salt) Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(PasswordHashingOptions.SALT_SIZE);
        var hash = HashValue(password, salt);
        var saltString = Convert.ToBase64String(salt);

        return (hash, saltString);
    }

    public static bool Verify(string givenPassword, string passwordHash)
    {
        var parts = passwordHash.Split(PasswordHashingOptions.PW_HASH_DENOMINATOR);
        var salt = parts[PasswordHashingOptions.SALT_POSITION];
        var hash = parts[PasswordHashingOptions.HASH_POSITION];

        var saltBytes = Convert.FromBase64String(salt);

        var givenPasswordHash = HashValue(givenPassword, saltBytes);

        return givenPasswordHash == hash;
    }

    private static string HashValue(string password, byte[] salt)
    {
        var keyBytes = KeyDerivation.Pbkdf2(
            password,
            salt,
            PasswordHashingOptions.ALGORITHM_TYPE,
            PasswordHashingOptions.ITERATION_COUNT,
            PasswordHashingOptions.KEY_SIZE);

        var hash = Convert.ToBase64String(keyBytes);

        return hash;
    }
}
