using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Docsy.API.Constants.Options;

public static class PasswordHashingOptions
{
    public const int ITERATION_COUNT = 10000;
    public const int SALT_SIZE = 16;
    public const KeyDerivationPrf ALGORITHM_TYPE = KeyDerivationPrf.HMACSHA512;
    public const int KEY_SIZE = 64;
    public const char PW_HASH_DENOMINATOR = ':';
    public const int SALT_POSITION = 0;
    public const int HASH_POSITION = 1;
}
