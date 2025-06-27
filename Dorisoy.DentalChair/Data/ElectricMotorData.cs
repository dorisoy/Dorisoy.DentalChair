namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 电动马达类
/// </summary>
public class ElectricMotorData(string startTime, string endTime, string reversibleDirection, string speed)
{
    /// <summary>
    /// 开始时间
    /// </summary>
    public string StartTime { get; } = startTime;

    /// <summary>
    /// 结束时间
    /// </summary>
    public string EndTime { get; } = endTime;

    /// <summary>
    /// 可逆方向
    /// </summary>
    public string ReversibleDirection { get; } = reversibleDirection;

    /// <summary>
    /// 速度
    /// </summary>
    public string Speed { get; } = speed;
}
