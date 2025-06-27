namespace Dorisoy.DentalChair.Protocols;

/// <summary>
/// 用于实现校验和的计算和验证
/// </summary>
internal class Checksum : DataFlowControl
{
    /// <summary>
    /// 计算数据的校验和并存储结果
    /// </summary>
    public override void ComputeData()
    {
        // 初始化结果数组为一个字节长
        Result = new byte[1];
        // 用于累加数据字节的总和
        int num = 0;
        for (int i = 0; i < Data.Length; i++)
        {
            // 累加每个字节的值
            num += Data[i];
        }
        // 取模256，确保结果在一个字节范围内
        num %= 256;
        // 计算校验和，取补码
        num = 255 - num;
        // 将计算结果存入结果数组
        Result[0] = (byte)num;
    }

    /// <summary>
    /// 验证数据的校验和是否正确
    /// </summary>
    /// <returns></returns>
    public override bool CheckData()
    {
        // 获取数据最后一个字节，作为校验和
        byte b = Data[Data.Length - 1];
        // 用于累加除校验和外的数据字节的总和
        int num = 0;
        for (int i = 0; i < Data.Length - 1; i++)
        {
            // 累加每个数据字节的值（排除最后一个校验和字节）
            num += Data[i];
        }
        // 取模256，确保结果在一个字节范围内
        num %= 256;
        // 计算应该的校验和
        num = 255 - num;
        // 将计算结果转为字节类型
        byte b2 = (byte)num;
        // 比较计算的校验和与数据中的校验和是否相同
        return b2 == b;
    }
}
