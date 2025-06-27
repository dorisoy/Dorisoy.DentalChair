namespace Dorisoy.DentalChair.Data.Enums;

/// <summary>
/// 定义 ChairCommand 枚举，用于表示椅位操作
/// </summary>
public enum ChairCommand : byte
{
    /// <summary>
    /// 座位上升
    /// </summary>
    SeatUp = 0x01,
    /// <summary>
    /// 座位下降
    /// </summary>
    SeatDown = 0x02,
    /// <summary>
    /// 靠背上升
    /// </summary>
    BackrestUp = 0x03,
    /// <summary>
    /// 靠背下降
    /// </summary>
    BackrestDown = 0x04,
    /// <summary>
    /// 椅位0
    /// </summary>
    Position0 = 0x05,
    /// <summary>
    /// 椅位1
    /// </summary>
    Position1 = 0x06,
    /// <summary>
    /// 椅位2
    /// </summary>
    Position2 = 0x07,
    /// <summary>
    /// 椅位3
    /// </summary>
    Position3 = 0x08,
    /// <summary>
    /// 椅位LP
    /// </summary>
    PositionLP = 0x09,
    /// <summary>
    /// 急救椅位
    /// </summary>
    Emergency = 0x0A,
    /// <summary>
    /// 上报椅子信息
    /// </summary>
    ReportInfo = 0x0B
}


/// <summary>
/// 定义 ChairSetCommand 枚举，用于表示椅位设置操作
/// </summary>
public enum ChairSetCommand : byte
{
    /// <summary>
    /// 椅位1设置
    /// </summary>
    Position1Set = 0x01,
    /// <summary>
    /// 椅位2设置
    /// </summary>
    Position2Set = 0x02,
    /// <summary>
    /// 椅位3设置
    /// </summary>
    Position3Set = 0x03,
    /// <summary>
    /// 椅位LP设置
    /// </summary>
    PositionLPSet = 0x04,
    /// <summary>
    /// 自动设置极限椅位
    /// </summary>
    AutoLimitPositionSet = 0x05,
    /// <summary>
    /// 手动设置极限椅位时归零
    /// </summary>
    ManualLimitResetPosition = 0x06,
    /// <summary>
    /// 手动设置极限椅位(椅位最低，椅背最仰)
    /// </summary>
    ManualLimitPositionLow = 0x07,
    /// <summary>
    /// 手动设置极限椅位(椅位最高，椅背最俯)
    /// </summary>
    ManualLimitPositionHigh = 0x08,
    /// <summary>
    /// 上报椅位存储信息
    /// </summary>
    ReportStoredPositionInfo = 0x09,
    /// <summary>
    /// 自动设置极限椅位设置结束
    /// </summary>
    AutoLimitSetEnd = 0x0A
}

/// <summary>
/// 定义 ChairId 枚举，用于表示椅位编号
/// </summary>
public enum ChairId : byte
{
    /// <summary>
    /// 椅位 0
    /// </summary>
    Position0 = 0x01,
    /// <summary>
    /// 椅位 1
    /// </summary>
    Position1 = 0x02,
    /// <summary>
    /// 椅位 2
    /// </summary>
    Position2 = 0x03,
    /// <summary>
    /// 椅位 3
    /// </summary>
    Position3 = 0x04,
    /// <summary>
    /// 椅位 LP
    /// </summary>
    PositionLP = 0x05,
    /// <summary>
    /// 急救椅位
    /// </summary>
    Emergency = 0x06,
    /// <summary>
    /// 极限椅位高
    /// </summary>
    LimitHighPosition = 0x08,
    /// <summary>
    /// 极限椅位低
    /// </summary>
    LimitLowPosition = 0x09
}