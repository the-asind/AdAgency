namespace AdAgency.Models;

using System;
using System.Security.Cryptography;
using System.Text;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        var builder = new StringBuilder();
        foreach (var t in bytes)
            builder.Append(t.ToString("x2"));
        return builder.ToString();
    }
}