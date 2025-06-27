namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 洁牙机
/// </summary>
public class LiftingMotorData(string startHeight, string endHeight, string status)
{
    /// <summary>
    /// 起始高度
    /// </summary>
    public string StartHeight { get; } = startHeight;
    /// <summary>
    /// 结束高度
    /// </summary>
    public string EndHeight { get; } = endHeight;
    /// <summary>
    /// 状态
    /// </summary>
    public string Status { get; } = status;
}
