namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 清洗记录类
/// </summary>
public class HistoryData(long time, bool start, bool isClear, bool isCheck)
{
    /// <summary>
    /// 时间
    /// </summary>
    public long Time { get; } = time;
    /// <summary>
    /// 是否开始
    /// </summary>
    public bool Start { get; } = start;
    /// <summary>
    /// 是否清除
    /// </summary>
    public bool IsClear { get; } = isClear;
    /// <summary>
    /// 是否检查
    /// </summary>
    public bool IsCheck { get; set; } = isCheck;
}
