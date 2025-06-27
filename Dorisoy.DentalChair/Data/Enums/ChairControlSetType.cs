namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 椅位控制设置类型枚举
/// </summary>
public enum ChairControlSetType
{
    /// <summary>
    /// 无
    /// </summary>
    None = 0,
   /// <summary>
    /// 记忆1
    /// </summary>
    Chair1 = 1,
    /// <summary>
    /// 记忆2
    /// </summary>
    Chair2 = 2,
    /// <summary>
    /// 记忆3
    /// </summary>
    Chair3 = 3,
    /// <summary>
    /// 椅位Lp（吐痰）
    /// </summary>
    ChairLp = 4,
    /// <summary>
    /// 状态
    /// </summary>
    Status = 11
}

/// <summary>
/// 椅位控制设置类型扩展
/// </summary>
public static class ChairControlSetTypeExtensions
{
    private static readonly Dictionary<int, ChairControlSetType> map = new()
    {
        { 0,ChairControlSetType.None },
        { 1,ChairControlSetType.Chair1 },
        { 2,ChairControlSetType.Chair2 },
        { 3,ChairControlSetType.Chair3 },
        { 4,ChairControlSetType.ChairLp },
        { 11,ChairControlSetType.Status }
    };

    public static ChairControlSetType FromInt(int type)
    {
        return map.TryGetValue(type, out var setType) ? setType : ChairControlSetType.None;
    }
}
