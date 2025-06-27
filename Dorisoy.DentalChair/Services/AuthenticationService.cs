using SQLite;

namespace Dorisoy.DentalChair.Services;

/// <summary>
/// �����û���֤����
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    private readonly DatabaseService _databaseService;

    public AuthenticationService(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    /// <summary>
    /// ע���û�
    /// </summary>
    /// <param name="name"></param>
    /// <param name="sex"></param>
    /// <param name="password"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<bool> RegisterUserAsync(string name, string sex, string password, string email)
    {
        var db = _databaseService.GetConnection();

        var existingUser = await db.Table<User>().FirstOrDefaultAsync(u => u.Name == name);
        if (existingUser != null)
        {
            return false;
        }

        var user = new User
        {
            Name = name,
            Sex = sex,
            Password = password,
            Email = email,
            CreatedAt = DateTime.Now
        };

        await db.InsertAsync(user);
        return true;
    }

    /// <summary>
    ///  ��¼�û�
    /// </summary>
    /// <param name="name"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<User?> LoginUserAsync(string name, string password)
    {
        var db = _databaseService.GetConnection();

        var user = await db.Table<User>().FirstOrDefaultAsync(u => u.Name == name && u.Password == password);
        if (user == null)
        {
            return null;
        }

        return user;
    }

    /// <summary>
    /// ���ӽ�ɫ
    /// </summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public async Task<bool> AddRoleAsync(string roleName)
    {
        var db = _databaseService.GetConnection();

        var existingRole = await db.Table<Role>().FirstOrDefaultAsync(r => r.Name == roleName);
        if (existingRole != null)
        {
            return false;
        }

        var role = new Role
        {
            Name = roleName,
            CreatedAt = DateTime.Now
        };

        await db.InsertAsync(role);
        return true;
    }

    /// <summary>
    /// �����ɫ���û�
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public async Task<bool> AssignRoleToUserAsync(int userId, int roleId)
    {
        var db = _databaseService.GetConnection();

        var user = await db.FindAsync<User>(userId);
        var role = await db.FindAsync<Role>(roleId);
        if (user == null || role == null)
        {
            return false;
        }

        var existingUserRole = await db.Table<UserRole>()
            .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        if (existingUserRole != null)
        {
            return false;
        }

        var userRole = new UserRole
        {
            UserId = userId,
            RoleId = roleId,
            CreatedAt = DateTime.Now
        };

        await db.InsertAsync(userRole);
        return true;
    }

    /// <summary>
    /// ��ȡ�����û��б�
    /// </summary>
    /// <returns></returns>
    public async Task<List<User>> GetAllUsersAsync()
    {
        var db = _databaseService.GetConnection();
        return await db.Table<User>().ToListAsync();
    }

    /// <summary>
    /// ��ȡ���н�ɫ�б�
    /// </summary>
    /// <returns></returns>
    public async Task<List<Role>> GetAllRolesAsync()
    {
        var db = _databaseService.GetConnection();
        return await db.Table<Role>().ToListAsync();
    }

    /// <summary>
    /// �ж��û��Ƿ����
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<bool> UserExistsAsync(string name)
    {
        var db = _databaseService.GetConnection();
        var user = await db.Table<User>().FirstOrDefaultAsync(u => u.Name == name);
        return user != null;
    }

    /// <summary>
    /// �ж��û���ɫ�Ƿ����
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public async Task<bool> UserRoleExistsAsync(int userId, int roleId)
    {
        var db = _databaseService.GetConnection();
        var userRole = await db.Table<UserRole>().FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        return userRole != null;
    }

    /// <summary>
    /// ��ȡָ���û�
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<User?> GetUserByNameAsync(string name)
    {
        var db = _databaseService.GetConnection();
        return await db.Table<User>().FirstOrDefaultAsync(u => u.Name == name);
    }

    /// <summary>
    /// ��ȡָ����ɫ
    /// </summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public async Task<Role?> GetRoleByNameAsync(string roleName)
    {
        var db = _databaseService.GetConnection();
        return await db.Table<Role>().FirstOrDefaultAsync(r => r.Name == roleName);
    }

    /// <summary>
    /// ɾ���û�
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteUserAsync(int userId)
    {
        var db = _databaseService.GetConnection();
        var user = await db.FindAsync<User>(userId);
        if (user == null)
        {
            return false;// �û�������
        }

        await db.DeleteAsync(user);
        return true;
    }

    /// <summary>
    /// �����û�
    /// </summary>
    /// <param name="updatedUser"></param>
    /// <returns></returns>
    public async Task<bool> UpdateUserAsync(User updatedUser)
    {
        var db = _databaseService.GetConnection();
        var existingUser = await db.FindAsync<User>(updatedUser.Id);
        if (existingUser == null)
        {
            return false;// �û�������
        }

        existingUser.Name = updatedUser.Name;
        existingUser.Sex = updatedUser.Sex;
        existingUser.CreatedAt = updatedUser.CreatedAt;

        await db.UpdateAsync(existingUser);
        return true;
    }

    /// <summary>
    /// ɾ����ɫ
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteRoleAsync(int roleId)
    {
        var db = _databaseService.GetConnection();
        var role = await db.FindAsync<Role>(roleId);
        if (role == null)
        {
            return false;// ��ɫ������
        }

        await db.DeleteAsync(role);
        return true;
    }

    /// <summary>
    /// ���½�ɫ
    /// </summary>
    /// <param name="updatedRole"></param>
    /// <returns></returns>
    public async Task<bool> UpdateRoleAsync(Role updatedRole)
    {
        var db = _databaseService.GetConnection();
        var existingRole = await db.FindAsync<Role>(updatedRole.Id);
        if (existingRole == null)
        {
            return false;// ��ɫ������
        }

        existingRole.Name = updatedRole.Name;
        existingRole.CreatedAt = updatedRole.CreatedAt;

        await db.UpdateAsync(existingRole);
        return true;
    }
}