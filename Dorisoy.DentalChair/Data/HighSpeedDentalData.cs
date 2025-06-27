namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 高速手机类
/// </summary>
public class HighSpeedDentalData(string startTime, string endTime, string power)
{
    /// <summary>
    /// 启始时间
    /// </summary>
    public string StartTime { get; } = startTime;
    /// <summary>
    /// 启始时间
    /// </summary>
    public string EndTime { get; } = endTime;
    /// <summary>
    /// 功率
    /// </summary>
    public string Power { get; } = power;
}
