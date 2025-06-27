using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorisoy.DentalChair.Data.Enums;

/// <summary>
/// 定义 GargleCommand 枚举，用于表示各种漱口操作
/// </summary>
public enum GargleCommand : byte
{
    /// <summary>
    /// 设置杯水时间
    /// </summary>
    SetCupWaterTime = 0x01,
    /// <summary>
    /// 设置感应取水
    /// </summary>
    SetWaterInduction = 0x02,
    /// <summary>
    /// 开始漱口
    /// </summary>
    StartGargle = 0x03,
    /// <summary>
    /// 结束漱口
    /// </summary>
    EndGargle = 0x04,
    /// <summary>
    /// 漱口状态上报
    /// </summary>
    ReportGargleStatus = 0x05
}
