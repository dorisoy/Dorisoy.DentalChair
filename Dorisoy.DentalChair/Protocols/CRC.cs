namespace Dorisoy.DentalChair.Protocols;

/// <summary>
/// 使用 CCITT 标准进行 CRC（循环冗余校验）的计算
/// </summary>
internal class CRC : DataFlowControl
{
    /// <summary>
    /// 计算数据的CRC（循环冗余校验）并存储结果
    /// </summary>
    public override void ComputeData()
    {
        // 初始化结果数组为两个字节长
        Result = new byte[2];
        // 初始化CRC变量为无符号短整型的最大值
        // 逐字节计算数据的CRC值
        ushort crc = ushort.MaxValue;
        for (int i = 0; i < Data.Length; i++)
        {
            // 调用方法计算当前字节对CRC的影响
            CalcCRC_CCITT(ref crc, Data[i]);
        }
        // 将CRC值转为十六进制格式的字符串
        string arg = $"{crc:X}";
        // 打印计算结果到控制台
        Console.WriteLine("Resultat crc :{0}", arg);
        // 结果的高字节
        Result[0] = (byte)((uint)(crc >> 8) & 0xFFu);
        // 结果的低字节
        Result[1] = (byte)(crc & 0xFFu);
    }

    /// <summary>
    /// 检查数据有效性（此处未具体实现，仅返回true）
    /// </summary>
    /// <returns></returns>
    public override bool CheckData()
    {
        return true;
    }

    /// <summary>
    /// 计算CCITT标准的CRC值
    /// </summary>
    /// <param name="crc"></param>
    /// <param name="car"></param>
    private void CalcCRC_CCITT(ref ushort crc, ushort car)
    {
        // 反转CRC的字节序
        crc = (ushort)((crc >> 8) | (crc << 8));
        // 将当前字节与CRC异或
        crc ^= car;
        // 取右移四位后的最低四位，与CRC异或
        crc ^= (ushort)((crc >> 4) & 0xF);
        // 将CRC左移12位，并与自身异或
        crc ^= (ushort)(crc << 12);
        // 将CRC左移5位后的结果与CRC异或
        crc ^= (ushort)((crc << 5) & 0x1FE0);
    }
}
