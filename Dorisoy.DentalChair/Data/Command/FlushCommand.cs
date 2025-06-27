namespace Dorisoy.DentalChair.Data.Enums;

/// <summary>
/// 定义 FlushCommand 枚举，用于表示各种冲盂操作
/// </summary>
public enum FlushCommand : byte
{
    /// <summary>
    /// 设置冲盂时间
    /// </summary>
    SetFlushTime = 0x01,
    /// <summary>
    /// 开始转动电动痰盂
    /// </summary>
    StartRotation = 0x02,
    /// <summary>
    /// 结束转动电动痰盂
    /// </summary>
    EndRotation = 0x03,
    /// <summary>
    /// 开始冲盂
    /// </summary>
    StartFlush = 0x04,
    /// <summary>
    /// 结束冲盂
    /// </summary>
    EndFlush = 0x05,
    /// <summary>
    /// 冲盂状态上报
    /// </summary>
    ReportFlushStatus = 0x06
}
