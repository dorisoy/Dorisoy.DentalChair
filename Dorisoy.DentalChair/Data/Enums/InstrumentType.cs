namespace Dorisoy.DentalChair.Data;


/// <summary>
/// 定义 InstrumentCommand 枚举，用于表示器械操作
/// </summary>
public enum InstrumentCommand : byte
{
    /// <summary>
    /// 光纤灯
    /// </summary>
    FiberOptic = 0x01,
    /// <summary>
    /// 调速模式
    /// </summary>
    SpeedControlMode = 0x02,
    /// <summary>
    /// 定速巡航模式
    /// </summary>
    CruiseControlMode = 0x03,
    /// <summary>
    /// 电动马达方向（正反转）
    /// </summary>
    MotorDirection = 0x04,
    /// <summary>
    /// 功率设置
    /// </summary>
    PowerSetting = 0x05,
    /// <summary>
    /// 电动马达转速
    /// </summary>
    MotorSpeedSetting = 0x06,
    /// <summary>
    /// 水量调节
    /// </summary>
    WaterAdjustment = 0x07,
    /// <summary>
    /// 速度比调节
    /// </summary>
    SpeedRatioAdjustment = 0x08,
    /// <summary>
    /// 亮度调节
    /// </summary>
    BrightnessAdjustment = 0x09  
}

/// <summary>
/// 定义 InstrumentType 枚举，用于表示器械类型
/// </summary>
public enum InstrumentType : byte
{
    None = 0x00,
    /// <summary>
    /// 高速手机/光纤
    /// </summary>
    HighSpeedHandpiece = 0x01,
    /// <summary>
    /// 低速手机/光纤
    /// </summary>
    LowSpeedHandpiece = 0x02,
    /// <summary>
    /// 电动马达
    /// </summary>
    ElectricMotor = 0x03,
    /// <summary>
    /// 洁牙机
    /// </summary>
    UltrasonicScaler = 0x04,
    /// <summary>
    /// 内窥镜（保留）
    /// </summary>
    EndoscopeReserved = 0x05,
    /// <summary>
    /// 口扫（保留）
    /// </summary>
    IntraoralScannerReserved = 0x06,
    /// <summary>
    /// 面扫（保留）
    /// </summary>
    PanoramaScannerReserved = 0x07  
}

/// <summary>
/// 定义 FeedbackCommand 枚举，用于表示反馈操作
/// </summary>
public enum FeedbackCommand : byte
{
    /// <summary>
    /// 器械拿起
    /// </summary>
    InstrumentPicked = 0x01,
    /// <summary>
    /// 器械放下
    /// </summary>
    InstrumentPutDown = 0x02,
    /// <summary>
    /// 踏板踩下上报
    /// </summary>
    PedalPressedReported = 0x03,
    /// <summary>
    /// 踏板松开上报
    /// </summary>
    PedalReleasedReported = 0x04,
    /// <summary>
    /// 实时功率/转速上报
    /// </summary>
    PowerSpeedReported = 0x05  
}


/// <summary>
/// 器械类型扩展
/// </summary>
public static class InstrumentTypeExtensions
{
    private static readonly Dictionary<int, InstrumentType> map = new()
    {
       { 0,InstrumentType.None },
       { 1,InstrumentType.HighSpeedHandpiece },
       { 2,InstrumentType.LowSpeedHandpiece },
       { 3,InstrumentType.ElectricMotor },
       { 4,InstrumentType.UltrasonicScaler },
       { 5,InstrumentType.EndoscopeReserved },
       { 6,InstrumentType.IntraoralScannerReserved },
       { 7,InstrumentType.PanoramaScannerReserved }
    };

    public static InstrumentType FromInt(int type)
    {
        return map.TryGetValue(type, out var instrumentType) ? instrumentType : InstrumentType.None;
    }
}
