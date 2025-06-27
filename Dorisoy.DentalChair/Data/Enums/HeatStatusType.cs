namespace Dorisoy.DentalChair.Data;


/// <summary>
/// 加热状态类型枚举
/// </summary>
public enum HeatStatusType
{
    None = 0,
    Start = 2,
    Finish = 1
}

/// <summary>
/// 加热状态扩展
/// </summary>
public static class HeatStatusTypeExtensions
{
    private static readonly Dictionary<int, HeatStatusType> map = new()
    {
       { 0,HeatStatusType.None },
       { 2,HeatStatusType.Start },
       { 1,HeatStatusType.Finish }
    };

    public static HeatStatusType FromInt(int type)
    {
        return map.TryGetValue(type, out var statusType) ? statusType : HeatStatusType.None;
    }
}


/// <summary>
/// 表示加热控制的业务指令
/// </summary>
public enum HeatCommand : byte
{
    SetTemperature = 0x01, // 设置加热温度
    StartHeating = 0x02,   // 开始加热
    StopHeating = 0x03,    // 停止加热
    ReportStatus = 0x04    // 上报加热状态
}