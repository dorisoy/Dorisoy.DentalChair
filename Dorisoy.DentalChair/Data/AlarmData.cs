namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 闹钟
/// </summary>
public class AlarmData(int min, int sec)
{
    /// <summary>
    /// 表示分钟
    /// </summary>
    public int Min { get; set; } = min;

    /// <summary>
    /// 表示秒数
    /// </summary>
    public int Sec { get; set; } = sec;
}
