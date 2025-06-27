namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 电压类型枚举
/// </summary>
public enum VoltageType
{
    None = 0,
    Normal = 1,
    High = 2,
    Low = 3
}

/// <summary>
/// 电压类型扩展
/// </summary>
public static class VoltageTypeExtensions
{
    private static readonly Dictionary<int, VoltageType> map = new()
    {
       { 0,VoltageType.None },
       { 1,VoltageType.Normal },
       { 2,VoltageType.High },
       { 3,VoltageType.Low }
    };

    public static VoltageType FromInt(int type)
    {
        return map.TryGetValue(type, out var voltageType) ? voltageType : VoltageType.None;
    }
}
