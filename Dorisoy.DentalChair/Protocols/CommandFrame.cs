using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorisoy.DentalChair.Protocols;

/// <summary>
/// 表示DentalChair上位机通信协议的指令帧
/// </summary>
public class CommandFrame
{
    /// <summary>
    /// 表示字节头
    /// </summary>
    public byte Header { get; } = 0xFA;

    /// <summary>
    /// 表示功能码
    /// </summary>
    public byte[] FunctionCode { get; private set; } = new byte[2];

    /// <summary>
    /// 表示数据位
    /// </summary>
    public byte[] Data { get; private set; } = new byte[20];

    /// <summary>
    /// 表示校验位
    /// </summary>
    public byte Checksum { get; private set; }

    /// <summary>
    /// 表示字节尾
    /// </summary>
    public byte Footer { get; } = 0xEA;

    /// <summary>
    /// 初始化指令帧
    /// </summary>
    /// <param name="functionCode">功能码</param>
    /// <param name="data">数据位</param>
    public CommandFrame(byte[] functionCode, byte[]? data = null)
    {
        if (functionCode.Length != 2)
            throw new ArgumentException("功能码必须为2字节长度", nameof(functionCode));

        FunctionCode = functionCode;

        if (data != null)
        {
            Array.Copy(data, Data, Math.Min(data.Length, Data.Length));
        }

        ComputeChecksum();
    }

    /// <summary>
    /// 计算校验码（累加和）
    /// </summary>
    private void ComputeChecksum()
    {
        Checksum = (byte)(Header + FunctionCode.Sum(b => b) + Data.Sum(b => b));
    }

    /// <summary>
    /// 获取完整的字节帧
    /// </summary>
    /// <returns>字节数组</returns>
    public byte[] GetFrame()
    {
        return new byte[] { Header }
            .Concat(FunctionCode)
            .Concat(Data)
            .Concat(new byte[] { Checksum, Footer })
            .ToArray();
    }
}
