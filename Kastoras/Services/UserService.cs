using System;
using System.Threading.Tasks;
using Kastoras.Models;
using Kastoras.Repos;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Kastoras.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<UserModel> _passwordHasher;

    public UserService(IUserRepository userRepository, IPasswordHasher<UserModel> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserModel> RegisterUser(string username, string email, string password)
    {
        var user = new UserModel
        {
            Username = username,
            Email = email,
            Salt = GenerateSalt(),
            DateRegistered = DateTime.UtcNow,
            IsActive = true
        };

        user.HashedPassword = _passwordHasher.HashPassword(user, password + user.Salt);

        await _userRepository.AddUser(user);
        return user;
    }

    public async Task<bool> ValidateUser(string username, string password)
    {
        var user = await _userRepository.GetUserByUsername(username);
        if (user == null) return false;

        var result = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, password + user.Salt);
        return result == PasswordVerificationResult.Success;
    }

    private string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }
}