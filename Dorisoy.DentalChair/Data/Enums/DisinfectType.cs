namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 消毒类型枚举
/// </summary>
public enum DisinfectType
{
    /// <summary>
    /// 无
    /// </summary>
    None = 0,
    /// <summary>
    /// 消毒
    /// </summary>
    Disinfect = 1,
    /// <summary>
    /// 冲洗
    /// </summary>
    Watch = 2,
    /// <summary>
    /// 吹气
    /// </summary>
    Scavenging = 3,
    /// <summary>
    /// 消毒中
    /// </summary>
    Process = 5,
    /// <summary>
    /// 消毒结束
    /// </summary>
    Stop = 6
}

/// <summary>
/// 器械踏板类型扩展
/// </summary>
public static class DisinfectTypeExtensions
{
    private static readonly Dictionary<int, DisinfectType> map = new()
    {
       { 0,DisinfectType.None },
       { 1,DisinfectType.Disinfect },
       { 2,DisinfectType.Watch },
       { 3,DisinfectType.Scavenging },
       { 5,DisinfectType.Process },
       { 6,DisinfectType.Stop }
    };

    public static DisinfectType FromInt(int type)
    {
        return map.TryGetValue(type, out var disinfectType) ? disinfectType : DisinfectType.None;
    }
}
