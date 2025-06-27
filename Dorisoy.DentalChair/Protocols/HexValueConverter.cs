using System.Text;

namespace Dorisoy.DentalChair.Protocols;

/// <summary>
/// 用于采集协议数据解析
/// ========================
/// 生成信号字节:
/// byte gunSignal = HexValueConverter.GetHexValue(highSpeed:true,lowSpeed:false,motor:true,toothCleaner:false);
/// gunSignal : 0b1010 (即 10)
/// ------------------------------
/// 解析信号字节:
/// HexValueConverter.Devices state = HexValueConverter.GetDeviceStates(gunSignal);
/// state ：HighSpeed,Motor
/// </summary>
public static class HVC
{
    /// <summary>
    /// 定义设备枚举，使得高速是1000，低速是0100等
    /// </summary>
    [Flags]
    public enum Devices : byte
    {
        None = 0,         // 0000
        /// <summary>
        /// 洁牙机
        /// </summary>
        ToothCleaner = 1, // 0001
        /// <summary>
        /// 马达
        /// </summary>
        Motor = 2,        // 0010
        /// <summary>
        /// 低速
        /// </summary>
        LowSpeed = 4,     // 0100
        /// <summary>
        /// 高速
        /// </summary>
        HightSpeed = 8     // 1000
    }

    /// <summary>
    /// 获取枪架HEX状态位
    /// </summary>
    /// <param name="highSpeed">高速</param>
    /// <param name="lowSpeed">低速</param>
    /// <param name="motor">马达</param>
    /// <param name="toothCleaner">洁牙机</param>
    /// <returns></returns>
    public static ushort GetHexValue(bool highSpeed, bool lowSpeed, bool motor, bool toothCleaner)
    {
        // 将布尔值转换为枚举
        Devices deviceState = (highSpeed ? Devices.HightSpeed : Devices.None) |
                              (lowSpeed ? Devices.LowSpeed : Devices.None) |
                              (motor ? Devices.Motor : Devices.None) |
                              (toothCleaner ? Devices.ToothCleaner : Devices.None);

        // 将枚举转换为低字节的二进制表示
        byte lowerByte = (byte)deviceState;

        // 组合高字节和低字节，得到最终的Hex值
        ushort hexValue = lowerByte;
        return hexValue;
    }


    /// <summary>
    /// 解析hexValue并获取设备状态
    /// </summary>
    /// <param name="hexValue"></param>
    /// <returns></returns>
    public static Devices GetDeviceStates(ushort hexValue)
    {
        // 只考虑低字节的值
        return (Devices)(byte)(hexValue & 0x00FF);
    }

    /// <summary>
    /// 线性转换方程
    /// </summary>
    /// <param name="input"></param>
    /// <param name="min_input"></param>
    /// <param name="max_input"></param>
    /// <param name="min_height"></param>
    /// <param name="max_height"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static double ConvertInputToHeight(int input, double min_input = 510, double max_input = 1019, double min_height = 38.3, double max_height = 70.38)
    {
        // 如果输入值小于最小输入值或大于最大输入值，则抛出异常
        if (input < min_input || input > max_input)
        {
            throw new ArgumentOutOfRangeException(nameof(input), "Input value must be between 0 and 900.");
        }
        // 使用线性映射公式将输入值转换为高度
        double height = min_height + ((max_height - min_height) / (max_input - min_input)) * (input - min_input);
        return height;
    }

    /// <summary>
    /// 读取两个字节，并转换为一个 UInt16（使用大端序）
    /// </summary>
    /// <param name="message"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static ushort ReadUint16(byte[] message, ref int index)
    {
        ushort value = (ushort)(message[index] << 8 | message[index + 1]);
        index += 2;
        return value;
    }

    /// <summary>
    /// 将16进制字符串转ByteArray
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    public static byte[] HexStringToByteArray(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < hex.Length; i += 2)
        {
            bytes[i / 2] = byte.Parse(hex.Substring(i, 2), NumberStyles.HexNumber);
        }
        return bytes;
    }

    /// <summary>
    /// 字节转16进制字符串
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string ByteBlockToHexString(byte[] bytes)
    {
        // 检查 bytes 数组是否全部元素都是 0
        if (bytes.All(b => b == 0))
        {
            // 如果全是 0，返回空字符串或特定占位符
            return string.Empty;
        }
        // 使用 StringBuilder 来构建最终的 HEX 字符串
        var hex = new StringBuilder(bytes.Length * 2);
        // 遍历字节数据并将每个字节转换为十六进制字符串
        foreach (byte b in bytes)
        {
            hex.Append(b.ToString("x2"));
            hex.Append(' ');
        }
        return hex.ToString();
    }

}
