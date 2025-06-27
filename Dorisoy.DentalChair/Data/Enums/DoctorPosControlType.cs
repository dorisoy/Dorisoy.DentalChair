namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 医生位控制类型枚举
/// </summary>
public enum DoctorPosControlType
{
    /// <summary>
    /// 无
    /// </summary>
    None = 0,
    /// <summary>
    /// 医生位上移
    /// </summary>
    Up = 1,
    /// <summary>
    /// 医生位下移
    /// </summary>
    Down = 2,
    /// <summary>
    /// 导轨向前移动
    /// </summary>
    Forward = 3,
    /// <summary>
    /// 导轨向后移动
    /// </summary>
    Backward = 4,
    /// <summary>
    /// 医生位控制状态
    /// </summary>
    Status = 5
}


/// <summary>
/// 椅位控制类型扩展
/// </summary>
public static class DoctorPosTypeExtensions
{
    private static readonly Dictionary<int, DoctorPosControlType> map = new()
    {
       { 0,DoctorPosControlType.None },
       { 1,DoctorPosControlType.Up },
       { 2,DoctorPosControlType.Down },
       { 3,DoctorPosControlType.Forward },
       { 4,DoctorPosControlType.Backward },
       { 5,DoctorPosControlType.Status }
    };

    public static DoctorPosControlType FromInt(int type)
    {
        return map.TryGetValue(type, out var controlType) ? controlType : DoctorPosControlType.None;
    }
}

