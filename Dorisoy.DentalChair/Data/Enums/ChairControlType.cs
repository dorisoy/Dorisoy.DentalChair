namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 椅位控制类型枚举
/// </summary>
public enum ChairControlType
{
    /// <summary>
    /// 无
    /// </summary>
    None = 0,
    /// <summary>
    /// 上
    /// </summary>
    Up = 1,
    /// <summary>
    /// 下
    /// </summary>
    Down = 2,
    /// <summary>
    /// 俯
    /// </summary>
    HeadUp = 3,
    /// <summary>
    /// 仰
    /// </summary>
    HeadDown = 4,
    /// <summary>
    /// 0号椅位
    /// </summary>
    Chair0 = 5,
    /// <summary>
    /// 1号椅位
    /// </summary>
    Chair1 = 6,
    /// <summary>
    /// 2号椅位
    /// </summary>
    Chair2 = 7,
    /// <summary>
    /// 3号椅位
    /// </summary>
    Chair3 = 8,
    /// <summary>
    /// 椅位Lp（吐痰）
    /// </summary>
    ChairLp = 9,
    /// <summary>
    /// 椅位Aid（急救椅位）
    /// </summary>
    ChairAid = 10,
    /// <summary>
    /// 状态
    /// </summary>
    Status = 11
}

/// <summary>
/// 椅位控制类型扩展
/// </summary>
public static class ChairControlTypeExtensions
{
    private static readonly Dictionary<int, ChairControlType> map = new()
    {
       { 0,ChairControlType.None },
       { 1,ChairControlType.Up },
       { 2,ChairControlType.Down },
       { 3,ChairControlType.HeadUp },
       { 4,ChairControlType.HeadDown },
       { 5,ChairControlType.Chair0 },
       { 6,ChairControlType.Chair1 },
       { 7,ChairControlType.Chair2 },
       { 8,ChairControlType.Chair3 },
       { 9,ChairControlType.ChairLp },
       { 10,ChairControlType.ChairAid },
       { 11,ChairControlType.Status }
    };

    public static ChairControlType FromInt(int type)
    {
        return map.TryGetValue(type, out var controlType) ? controlType : ChairControlType.None;
    }
}
