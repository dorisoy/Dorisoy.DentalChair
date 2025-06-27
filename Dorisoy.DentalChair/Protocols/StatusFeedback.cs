namespace Dorisoy.DentalChair.Protocols;

/// <summary>
/// 表示状态反馈的结构体，包含枪架状态和其他传感器状态
/// </summary>
public struct StatusFeedback
{
    /// <summary>
    /// 枪架信号状态
    /// </summary>
    public byte GunSignal { get; set; }

    // 感应传感器状态反馈
    /// <summary>
    /// 是否缺水
    /// </summary>
    public bool HasWaterShortage { get; set; }

    /// <summary>
    /// 是否有漱口水
    /// </summary>
    public bool HasMouthwash { get; set; }

    /// <summary>
    /// 是否有冲盂水
    /// </summary>
    public bool HasFlushBasinWater { get; set; }

    /// <summary>
    /// 是否有口腔灯
    /// </summary>
    public bool HasOralLamp { get; set; }

    /// <summary>
    /// 助手位光电开关状态
    /// </summary>
    public bool HasAssistantLightSwitch { get; set; }

    /// <summary>
    /// 痰盂光电开关状态
    /// </summary>
    public bool HasSpittoonLightSwitch { get; set; }

    /// <summary>
    /// 电源电压是否低
    /// </summary>
    public bool IsLowPowerVoltage { get; set; }

    /// <summary>
    /// 电源电压是否高
    /// </summary>
    public bool IsHighPowerVoltage { get; set; }

    // 其他状态
    /// <summary>
    /// 屏幕是否已锁定
    /// </summary>
    public bool IsScreenLocked { get; set; }

    /// <summary>
    /// 是否需要痰盂避让
    /// </summary>
    public bool NeedsSpittoonAvoidance { get; set; }

    /// <summary>
    /// 将传感器状态转换为Byte19
    /// </summary>
    public byte ToByte19()
    {
        byte sensorStatus = 0;
        sensorStatus |= (byte)(HasWaterShortage ? 0x01 : 0x00);
        sensorStatus |= (byte)(HasMouthwash ? 0x02 : 0x00);
        sensorStatus |= (byte)(HasFlushBasinWater ? 0x04 : 0x00);
        sensorStatus |= (byte)(HasOralLamp ? 0x08 : 0x00);
        sensorStatus |= (byte)(HasAssistantLightSwitch ? 0x10 : 0x00);
        sensorStatus |= (byte)(HasSpittoonLightSwitch ? 0x20 : 0x00);
        sensorStatus |= (byte)(IsLowPowerVoltage ? 0x40 : 0x00);
        sensorStatus |= (byte)(IsHighPowerVoltage ? 0x80 : 0x00);
        return sensorStatus;
    }

    /// <summary>
    /// 将其他状态转换为Byte20
    /// </summary>
    public byte ToByte20()
    {
        byte otherStatus = 0;
        otherStatus |= (byte)(IsScreenLocked ? 0x01 : 0x00);
        otherStatus |= (byte)(NeedsSpittoonAvoidance ? 0x02 : 0x00);
        return otherStatus;
    }
}
