namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 刷卡类(DentalChair暂时不支持)
/// </summary>
public class CardData(string action, string location, string cardID)
{
    /// <summary>
    /// 行为
    /// </summary>
    public string Action { get; } = action;
    /// <summary>
    /// 位置
    /// </summary>
    public string Location { get; } = location;

    /// <summary>
    /// 卡片ID
    /// </summary>
    public string CardID { get; } = cardID;
}
