namespace Dorisoy.DentalChair.Data;


/// <summary>
/// 器械操作类型枚举
/// </summary>
public enum InstrumentOperateType
{
    None = 0,
    Fiber = 1,
    Variable = 2,
    Speed = 3,
    Direction = 4,
    Power = 5,
    MotorPower = 6
}

/// <summary>
/// 器械操作数据类型枚举
/// </summary>
public enum InstrumentOperateDataType
{
    None = 0,
    OFF = 1,
    ON = 2,
    FORWARD = 3,
    REVERSE = 4
}

/// <summary>
/// 器械操作数据类型扩展
/// </summary>
public static class InstrumentOperateDataTypeExtensions
{
    private static readonly Dictionary<int, InstrumentOperateDataType> map = new()
    {
       { 0,InstrumentOperateDataType.None },
       { 1,InstrumentOperateDataType.OFF },
       { 2,InstrumentOperateDataType.ON },
       { 3,InstrumentOperateDataType.FORWARD },
       { 4,InstrumentOperateDataType.REVERSE }
    };

    public static InstrumentOperateDataType FromInt(int type)
    {
        return map.TryGetValue(type, out var dataType) ? dataType : InstrumentOperateDataType.None;
    }
}
