using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorisoy.DentalChair.Data.Enums;

/// <summary>
/// 定义 MotorCommand 枚举，用于表示各种马达类型
/// </summary>
public enum MotorCommand : byte
{
    /// <summary>
    /// 0232马达
    /// </summary>
    Motor0232 = 0x01,
    /// <summary>
    /// DMX马达
    /// </summary>
    MotorDMX = 0x02,
    /// <summary>
    /// MC2马达
    /// </summary>
    MotorMC2 = 0x03  
}


/// <summary>
/// 定义 MotorOperation 枚举，总开关的操作
/// </summary>
public enum MotorOperation : byte
{
    /// <summary>
    /// 关
    /// </summary>
    Off = 0x01,
    /// <summary>
    /// 开
    /// </summary>
    On = 0x02  
}