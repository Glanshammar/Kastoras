using System;

namespace Kastoras.Models;

public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public string Salt { get; set; }
    public DateTime DateRegistered { get; set; }
    public DateTime LastLoginDate { get; set; }
    public bool IsActive { get; set; }
}