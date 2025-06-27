namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 冲洗类型枚举
/// </summary>
public enum WatchType
{
    None = 0,
    Process = 4,
    Stop = 5
}

/// <summary>
/// 冲洗类型扩展
/// </summary>
public static class WatchTypeExtensions
{
    private static readonly Dictionary<int, WatchType> map = new()
    {
       { 0,WatchType.None },
       { 4,WatchType.Process },
       { 5,WatchType.Stop }
    };

    public static WatchType FromInt(int type)
    {
        return map.TryGetValue(type, out var watchType) ? watchType : WatchType.None;
    }
}
