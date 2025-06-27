
namespace Dorisoy.DentalChair.Services
{
    public interface IAuthenticationService
    {
        Task<bool> AddRoleAsync(string roleName);
        Task<bool> AssignRoleToUserAsync(int userId, int roleId);
        Task<bool> DeleteRoleAsync(int roleId);
        Task<bool> DeleteUserAsync(int userId);
        Task<List<Role>> GetAllRolesAsync();
        Task<List<User>> GetAllUsersAsync();
        Task<Role?> GetRoleByNameAsync(string roleName);
        Task<User?> GetUserByNameAsync(string name);
        Task<User?> LoginUserAsync(string name, string password);
        Task<bool> RegisterUserAsync(string name, string sex, string password, string email);
        Task<bool> UpdateRoleAsync(Role updatedRole);
        Task<bool> UpdateUserAsync(User updatedUser);
        Task<bool> UserExistsAsync(string name);
        Task<bool> UserRoleExistsAsync(int userId, int roleId);
    }
}