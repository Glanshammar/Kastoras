using System.Threading.Tasks;
using Kastoras.Models;

namespace Kastoras.Repos;

public interface IUserRepository
{
    Task AddUser(UserModel user);
    Task<UserModel> GetUserByUsername(string username);
}