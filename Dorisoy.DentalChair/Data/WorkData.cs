namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 牙椅工作数据类
/// </summary>
public class WorkData(string status, string cardID)
{
    /// <summary>
    /// 状态
    /// </summary>
    public string Status { get; } = status;

    /// <summary>
    /// 卡ID
    /// </summary>
    public string CardID { get; } = cardID;
}
