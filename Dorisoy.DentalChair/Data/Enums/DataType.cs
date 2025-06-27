namespace Dorisoy.DentalChair.Data;


/// <summary>
/// 数据类型枚举
/// </summary>
public enum DataType
{
    /// <summary>
    /// 无
    /// </summary>
    None = 0,
    /// <summary>
    /// 为空
    /// </summary>
    No = 1,
    /// <summary>
    /// 不为空
    /// </summary>
    Have = 2
}

/// <summary>
/// 数据类型扩展
/// </summary>
public static class DataTypeExtensions
{
    private static readonly Dictionary<int, DataType> map = new()
    {
       { 0,DataType.None },
       { 1,DataType.No },
       { 2,DataType.Have }
    };

    public static DataType FromInt(int type)
    {
        return map.TryGetValue(type, out var dataType) ? dataType : DataType.None;
    }
}
