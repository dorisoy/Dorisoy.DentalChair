namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 器械踏板类型枚举
/// </summary>
public enum InstrumentPedalType
{
    None = 0,
    LeftPedal = 1
}

/// <summary>
/// 器械踏板类型扩展
/// </summary>
public static class InstrumentPedalTypeExtensions
{
    private static readonly Dictionary<int, InstrumentPedalType> map = new()
    {
       { 0,InstrumentPedalType.None },
       { 1,InstrumentPedalType.LeftPedal }
    };

    public static InstrumentPedalType FromInt(int type)
    {
        return map.TryGetValue(type, out var pedalType) ? pedalType : InstrumentPedalType.None;
    }
}
