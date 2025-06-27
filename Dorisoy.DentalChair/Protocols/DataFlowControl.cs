namespace Dorisoy.DentalChair.Protocols;

/// <summary>
/// 用于定义数据流控制的基本结构和行为
/// </summary>
internal abstract class DataFlowControl
{
    /// <summary>
    /// 定义一个枚举类型，用于表示数据校验的方式
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// 校验和
        /// </summary>
        CHECKSUM,
        /// <summary>
        /// 循环冗余校验
        /// </summary>
        CRC
    }

    /// <summary>
    /// 存储需要处理的数据的字节数组
    /// </summary>
    protected byte[] Data;

    /// <summary>
    /// 存储处理结果的字节数组
    /// </summary>
    protected byte[] Result;

    /// <summary>
    /// 设置需要处理的数据
    /// </summary>
    /// <param name="data"></param>
    public void SetData(byte[] data)
    {
        this.Data = data;
    }

    /// <summary>
    /// 获取处理结果
    /// </summary>
    /// <returns></returns>
    public byte[] GetResult()
    {
        return Result;
    }

    /// <summary>
    /// 抽象方法，计算数据
    /// </summary>
    public abstract void ComputeData();

    /// <summary>
    /// 抽象方法，检查数据
    /// </summary>
    /// <returns></returns>
    public abstract bool CheckData();
}
