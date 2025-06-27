namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 升降电机类
/// </summary>
public class PitchMotorData(string startAngle, string endAngle, string status)
{
    /// <summary>
    /// 起始角度
    /// </summary>
    public string StartAngle { get; } = startAngle;
    /// <summary>
    /// 结束角度
    /// </summary>
    public string EndAngle { get; } = endAngle;
    /// <summary>
    /// 状态
    /// </summary>
    public string Status { get; } = status;
}
