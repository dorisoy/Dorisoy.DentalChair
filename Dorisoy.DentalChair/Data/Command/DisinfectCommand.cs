namespace Dorisoy.DentalChair.Data.Enums;

/// <summary>
/// 定义 DisinfectCommand 枚举，用于表示消毒操作
/// </summary>
public enum DisinfectCommand : byte
{
    /// <summary>
    /// 进入消毒模式
    /// </summary>
    EnterDisinfectMode = 0x01,
    /// <summary>
    /// 退出消毒模式
    /// </summary>
    ExitDisinfectMode = 0x02,
    /// <summary>
    /// 设置消毒工作模式
    /// </summary>
    SetDisinfectWorkMode = 0x03,
    /// <summary>
    /// 开始消毒
    /// </summary>
    StartDisinfect = 0x04,
    /// <summary>
    /// 消毒过程反馈
    /// </summary>
    DisinfectProcessFeedback = 0x05,
    /// <summary>
    /// 消毒结束
    /// </summary>
    EndDisinfect = 0x06,
    /// <summary>
    /// 消毒开始前器械状态
    /// </summary>
    PreDisinfectInstrumentStatus = 0x07  
}

/// <summary>
/// 定义 DisinfectMode 枚举，用于表示消毒工作模式
/// </summary>
public enum DisinfectMode : byte
{
    /// <summary>
    /// 测试模式
    /// </summary>
    TestMode = 0x01,
    /// <summary>
    /// 工作模式
    /// </summary>
    WorkMode = 0x02,
    /// <summary>
    /// 消毒开始前
    /// </summary>
    BeforeStart = 0x00 
}
