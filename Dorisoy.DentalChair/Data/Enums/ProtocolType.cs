namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 下位机协议指令枚举
/// </summary>
public enum ProtocolType
{
    /// <summary>
    /// 自检 01
    /// </summary>
    Init,
    /// <summary>
    /// 设置配置参数 02
    /// </summary>
    SetUp,
    /// <summary>
    /// 下位机 上报状态 03
    /// </summary>
    Status,
    /// <summary>
    /// 下位机 上报故障 04
    /// </summary>
    Error,
    /// <summary>
    /// 加热控制 05
    /// </summary>
    Heat,
    /// <summary>
    /// 口腔灯控制 06
    /// </summary>
    Lighting,
    /// <summary>
    /// 漱口控制 07
    /// </summary>
    Gargle,
    /// <summary>
    /// 冲盂控制 08
    /// </summary>
    Flush,
    /// <summary>
    /// 马达模式设置 09
    /// </summary>
    Motor,
    /// <summary>
    /// 抽吸模式设置 0A
    /// </summary>
    Suction,
    /// <summary>
    /// 响铃控制 0B
    /// </summary>
    Ring,
    /// <summary>
    /// 椅位控制 0C
    /// </summary>
    Chair,
    /// <summary>
    /// 椅位设置 0D
    /// </summary>
    ChairSet,
    /// <summary> 
    /// 医生位控制 0E
    /// </summary>
    DoctorPos,
    /// <summary>
    /// 医生位设置(占时不支持记忆设置) 0F
    /// </summary>
    DoctorPosSet,
    /// <summary>
    /// 器械控制 10
    /// </summary>
    Instrument,
    /// <summary>
    /// 器械反馈 11
    /// </summary>
    Feedback,
    /// <summary>
    /// 联动设置 12
    /// </summary>
    Linkage,
    /// <summary>
    /// 光纤灯亮度设置 13
    /// </summary>
    FiberLight,
    /// <summary>
    /// 消毒 14
    /// </summary>
    Disinfect,
    /// <summary>
    /// 冲洗 15
    /// </summary>
    Watch,
    /// <summary>
    /// 锁定 16
    /// </summary>
    Lock
}
