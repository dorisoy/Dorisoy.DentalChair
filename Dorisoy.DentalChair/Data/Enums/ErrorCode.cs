using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorisoy.DentalChair.Data.Enums;

/// <summary>
/// 表示机器故障功能代码的枚举
/// </summary>
public enum ErrorCode : byte
{
    /// <summary>
    /// 牙椅升降电机故障
    /// </summary>
    ChairLiftMotorFailure = 0x01,

    /// <summary>
    /// 牙椅升降角度传感器故障
    /// </summary>
    ChairLiftAngleSensorFailure = 0x02,

    /// <summary>
    /// 俯仰电机故障
    /// </summary>
    ReclineMotorFailure = 0x03,

    /// <summary>
    /// 俯仰角度传感器故障
    /// </summary>
    ReclineAngleSensorFailure = 0x04,

    /// <summary>
    /// 器械盘升降电机故障
    /// </summary>
    InstrumentTrayLiftMotorFailure = 0x05,

    /// <summary>
    /// 滑轨电机故障
    /// </summary>
    SlideRailMotorFailure = 0x06,

    /// <summary>
    /// 总水汽电磁阀故障
    /// </summary>
    GeneralWaterAirSolenoidValveFailure = 0x07,

    /// <summary>
    /// 消毒水电磁阀故障
    /// </summary>
    DisinfectantSolenoidValveFailure = 0x08,

    /// <summary>
    /// 种植马达过热
    /// </summary>
    ImplantMotorOverheat = 0x09,

    /// <summary>
    /// 种植马达未连接
    /// </summary>
    ImplantMotorDisconnected = 0x0A,

    /// <summary>
    /// 种植马达堵转
    /// </summary>
    ImplantMotorStall = 0x0B,

    /// <summary>
    /// 洁牙机电源故障
    /// </summary>
    ToothCleanerPowerFailure = 0x0C,

    /// <summary>
    /// 种植机电源故障
    /// </summary>
    ImplantMachinePowerFailure = 0x0D,

    /// <summary>
    /// 洁牙机水电磁阀故障
    /// </summary>
    ToothCleanerWaterSolenoidValveFailure = 0x0E,

    /// <summary>
    /// 高速手机1控制气电磁阀故障
    /// </summary>
    HighSpeedHandpiece1ControlAirSolenoidValveFailure = 0x0F,

    /// <summary>
    /// 高速手机2控制气电磁阀故障
    /// </summary>
    HighSpeedHandpiece2ControlAirSolenoidValveFailure = 0x10,

    /// <summary>
    /// 低速手机控制气电磁阀故障
    /// </summary>
    LowSpeedHandpieceControlAirSolenoidValveFailure = 0x11,

    /// <summary>
    /// 蠕动泵故障
    /// </summary>
    PeristalticPumpFailure = 0x12,

    /// <summary>
    /// 冲盂电磁阀故障
    /// </summary>
    FlushSpittoonSolenoidValveFailure = 0x13,

    /// <summary>
    /// 漱口电磁阀故障
    /// </summary>
    MouthwashSolenoidValveFailure = 0x14,

    /// <summary>
    /// 消毒电磁阀故障
    /// </summary>
    DisinfectionSolenoidValveFailure = 0x15,

    /// <summary>
    /// 强吸电磁阀故障
    /// </summary>
    StrongSuctionSolenoidValveFailure = 0x16,

    /// <summary>
    /// 弱吸电磁阀故障
    /// </summary>
    WeakSuctionSolenoidValveFailure = 0x17,

    /// <summary>
    /// 脚开关电磁阀故障
    /// </summary>
    FootSwitchSolenoidValveFailure = 0x18,

    /// <summary>
    /// 加热水杯热传感器故障
    /// </summary>
    HeatCupTemperatureSensorFailure = 0x19,

    /// <summary>
    /// 电动痰盂电机故障
    /// </summary>
    ElectricSpittoonMotorFailure = 0x1A,

    /// <summary>
    /// 加热水杯故障
    /// </summary>
    HeatCupFailure = 0x1B,

    /// <summary>
    /// 口腔灯故障
    /// </summary>
    OralLampFailure = 0x1C,

    /// <summary>
    /// 进气压力过低
    /// </summary>
    IncomingAirPressureLow = 0x1D,

    /// <summary>
    /// 进水压力过低
    /// </summary>
    IncomingWaterPressureLow = 0x1E,

    /// <summary>
    /// 脚开关通信异常
    /// </summary>
    FootSwitchCommunicationException = 0x1F,

    /// <summary>
    /// 洁牙机异常（水阀故障）
    /// </summary>
    ToothCleanerAnomalyWaterValveFailure = 0x2A,

    /// <summary>
    /// 主控按键异常
    /// </summary>
    ControlPanelKeyAnomaly = 0x2B,

    /// <summary>
    /// 牙科椅板通信异常
    /// </summary>
    DentalChairBoardCommunicationException = 0x2C,

    /// <summary>
    /// 助手架通信异常
    /// </summary>
    AssistantArmCommunicationException = 0x2D,

    /// <summary>
    /// 医生位升降电机故障
    /// </summary>
    DoctorPositionLiftMotorFailure = 0x2E,

    /// <summary>
    /// 箱体板通信异常
    /// </summary>
    BoxPanelCommunicationException = 0x2F,

    /// <summary>
    /// 清除错误
    /// </summary>
    ClearError = 0xFF
}
