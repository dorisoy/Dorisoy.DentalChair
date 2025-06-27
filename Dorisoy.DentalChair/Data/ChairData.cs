namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 表示牙椅信息存储
/// </summary>
public class ChairData(int index, int high, int angle)
{
    /// <summary>
    /// 序号
    /// </summary>
    public int Index { get; } = index;

    /// <summary>
    /// 高度
    /// </summary>
    public int High { get; set; } = high;

    /// <summary>
    /// 角度
    /// </summary>
    public int Angle { get; set; } = angle;
}
