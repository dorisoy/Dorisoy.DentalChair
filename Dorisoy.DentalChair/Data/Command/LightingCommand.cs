namespace Dorisoy.DentalChair.Data.Enums;

/// <summary>
/// 定义 LightingCommand 枚举，用于表示各种口腔灯操作
/// </summary>
public enum LightingCommand : byte
{
    /// <summary>
    /// 口腔灯关
    /// </summary>
    Close = 0x01,
    /// <summary>
    /// 口腔灯开
    /// </summary>
    Open = 0x02,
    /// <summary>
    /// 口腔灯状态
    /// </summary>
    Status = 0x03
}


/// <summary>
/// 定义 RingCommand 枚举，用于表示响铃操作
/// </summary>
public enum RingCommand : byte
{
    /// <summary>
    /// 停止响铃
    /// </summary>
    Stop = 0x01,
    /// <summary>
    /// 开始响铃
    /// </summary>
    Start = 0x02 
}