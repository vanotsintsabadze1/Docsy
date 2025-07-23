namespace Docsy.API.Interfaces.PasswordUtility;

public interface IPasswordUtility
{
    (string Hash, string Salt) Hash(string password);
}
