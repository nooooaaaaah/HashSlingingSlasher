namespace HashSlingingSlasher;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;


public class PasswordHasher
{
    public static byte[] GenerateRandomSalt(int saltLength = 24)
    {
        byte[] salt = new byte[saltLength];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        if (string.IsNullOrEmpty(password)) { throw new ArgumentNullException(nameof(password)); }
        if (string.IsNullOrWhiteSpace(password)) { throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password)); }
        passwordSalt = GenerateRandomSalt(24);
        passwordHash = SHA256.HashData(Encoding.UTF8.GetBytes(password).Concat(passwordSalt).ToArray());
    }


    public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        if (password == null) { throw new ArgumentNullException(nameof(password)); }
        if (storedHash == null) { throw new ArgumentNullException(nameof(storedHash)); }
        if (storedSalt == null) { throw new ArgumentNullException(nameof(storedSalt)); }
        Console.WriteLine($"password hash length: {storedHash.Length}");
        Console.WriteLine($"password salt length: {storedSalt.Length}");
        if (storedHash.Length != 32) { throw new ArgumentException("Invalid length of password hash (32 bytes expected).", nameof(storedHash)); }
        if (storedSalt.Length != 24) { throw new ArgumentException("Invalid length of password salt (24 bytes expected).", nameof(storedSalt)); }
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(password).Concat(storedSalt).ToArray());
        for (int i = 0; i < hash.Length; i++)
        {
            if (hash[i] != storedHash[i]) return false;
        }
        return true;
    }
}

public class Hasher
{
    public static string HashFile(IFormFile file)
    {
        using Stream stream = file.OpenReadStream();
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(stream);
        StringBuilder builder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}