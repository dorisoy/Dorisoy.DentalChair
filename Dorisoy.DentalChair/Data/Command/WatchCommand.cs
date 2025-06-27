namespace Dorisoy.DentalChair.Data.Enums;

/// <summary>
/// 定义 WatchCommand 枚举，用于表示冲洗操作
/// </summary>
public enum WatchCommand : byte
{
    /// <summary>
    /// 进入冲洗模式
    /// </summary>
    EnterWashMode = 0x01,
    /// <summary>
    /// 进入冲洗模式
    /// </summary>
    ExitWashMode = 0x02,
    /// <summary>
    /// 开始冲洗
    /// </summary>
    StartWash = 0x03,
    /// <summary>
    /// 冲洗过程反馈
    /// </summary>
    WashProcessFeedback = 0x04,
    /// <summary>
    /// 冲洗结束
    /// </summary>
    EndWash = 0x05  
}
