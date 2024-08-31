using AdAgency.Data;

namespace AdAgency.Models;

public static class AuthenticationService
{
    private static string? _currentUserLogin;
    private static string? _currentUserPasswordHash;

    public static bool Login(string username, string hashedPassword, AdAgencyContext context)
    {
        var user = context.Users.SingleOrDefault(u => u.Username == username && u.PasswordHash == hashedPassword);

        if (user == null) return false;
        _currentUserLogin = username;
        _currentUserPasswordHash = hashedPassword;
        return true;
    }

    public static bool HasPermission(string requiredRole)
    {
        if (_currentUserLogin == null || _currentUserPasswordHash == null) return false;
        var user = new AdAgencyContext().Users.SingleOrDefault(u =>
            u.Username == _currentUserLogin && u.PasswordHash == _currentUserPasswordHash);
        return user?.Role == requiredRole;
    }
}