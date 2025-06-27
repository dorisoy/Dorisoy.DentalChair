namespace Dorisoy.DentalChair.Data.Enums;

/// <summary>
/// 定义 DoctorPosCommand 枚举，用于表示医生位操作
/// </summary>
public enum DoctorPosCommand : byte
{
    /// <summary>
    /// 导轨向前移动
    /// </summary>
    TrackForward = 0x01,
    /// <summary>
    /// 导轨向后移动
    /// </summary>
    TrackBackward = 0x02,
    /// <summary>
    /// 器械盘上升
    /// </summary>
    TrayUp = 0x03,
    /// <summary>
    /// 器械盘下降
    /// </summary>
    TrayDown = 0x04
}


/// <summary>
/// 定义 DoctorPosSetCommand 枚举，用于表示医生位设置操作
/// </summary>
public enum DoctorPosSetCommand : byte
{
    /// <summary>
    /// 导轨移动
    /// </summary>
    TrackMove = 0x01,
    /// <summary>
    /// 导械盘升降
    /// </summary>
    TrayLift = 0x02  
}