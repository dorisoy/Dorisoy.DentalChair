using SQLite;
using System.Diagnostics;

namespace Dorisoy.DentalChair.Services;

/// <summary>
/// 用于本地数据持久化存储
/// </summary>
public class DatabaseService
{
    private SQLiteAsyncConnection? _database;
    private readonly string _databasePath;

    public DatabaseService()
    {
        _databasePath = Path.Combine(FileSystem.AppDataDirectory, "Dorisoy.DentalChair.db");
        _database = new SQLiteAsyncConnection(_databasePath);

        _database.CreateTableAsync<User>().Wait();
        _database.CreateTableAsync<Role>().Wait();
        _database.CreateTableAsync<UserRole>().Wait();
    }

    /// <summary>
    /// 关闭数据库连接
    /// </summary>
    /// <returns></returns>
    public async Task CloseConnection()
    {
        try
        {
            if (_database != null)
            {
                await _database.CloseAsync();
                _database = null;
            }
        }
        catch { }
        finally 
        {
            Debug.WriteLine("数据库已经关闭！");
        }
    }

    /// <summary>
    /// 打开数据库连接
    /// </summary>
    public void ReopenConnection()
    {
        try
        {
            _database ??= new SQLiteAsyncConnection(_databasePath);
        }
        catch { }
        finally
        {
            Debug.WriteLine("数据库已经打开！");
        }
    }

    /// <summary>
    /// 获取数据库连接
    /// </summary>
    /// <returns></returns>
    public SQLiteAsyncConnection GetConnection()
    {
        ReopenConnection();
        return _database!;
    }
}
