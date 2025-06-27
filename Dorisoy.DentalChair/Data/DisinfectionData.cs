namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 清洗操作类
/// </summary>
public class DisinfectionData(string disinfectionType)
{
    /// <summary>
    /// 消毒类型
    /// </summary>
    public string DisinfectionType { get; } = disinfectionType;
}
