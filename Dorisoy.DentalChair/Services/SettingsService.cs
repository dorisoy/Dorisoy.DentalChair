using Newtonsoft.Json;

namespace Dorisoy.DentalChair.Services;

/// <summary>
/// 用于提供保存、检索和移除用户偏好配置, 使用 Preferences API 存储少量的键值对数据
/// </summary>
public class SettingsService
{
    /// <summary>
    /// 保存指定键和值的偏好设置，如果键已存在，其值将被更新。
    /// </summary>
    /// <param name="key">用于识别偏好的唯一键。</param>
    /// <param name="value">与给定键关联的值。</param>
    public void SavePreference(string key, string value)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("键不能为空或仅为空格。", nameof(key));
        }

        Preferences.Set(key, value);
    }

    /// <summary>
    /// 检索通过指定键存储的偏好设置，如果键不存在，则返回默认值。
    /// </summary>
    /// <param name="key">用于识别偏好的唯一键。</param>
    /// <param name="defaultValue">
    /// 如果键不存在，则返回的默认值。
    /// 如果未指定，默认为空字符串。
    /// </param>
    /// <returns>与指定键关联的值，或如果键不存在，则返回默认值。</returns>
    public string GetPreference(string key, string defaultValue = "")
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("键不能为空或仅为空格。", nameof(key));
        }

        return Preferences.Get(key, defaultValue);
    }

    /// <summary>
    /// 保存指定键和值的偏好设置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="data"></param>
    public void SavePreference<T>(string key, T data)
    {
        SavePreference(key.ToUpper(), JsonConvert.SerializeObject(data));
    }

    /// <summary>
    /// 检索通过指定键存储的偏好设置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public T? GetPreference<T>(string key, string defaultValue = "") where T : class
    {
        var data = GetPreference(key.ToUpper(), defaultValue);
        if (string.IsNullOrEmpty(data))
            return default;
        else
            return JsonConvert.DeserializeObject<T>(data);
    }

    /// <summary>
    /// 移除与指定键关联的偏好设置，如果键不存在，该方法不执行任何操作。
    /// </summary>
    /// <param name="key">用于识别待移除偏好的唯一键。</param>
    public void RemovePreference(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("键不能为空或仅为空格。", nameof(key));
        }

        Preferences.Remove(key);
    }
}