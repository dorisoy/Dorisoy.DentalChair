namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 口腔灯状态类
/// </summary>
public class SurgicalLampData(string status)
{
    /// <summary>
    /// 状态
    /// </summary>
    public string Status { get; } = status;
}
