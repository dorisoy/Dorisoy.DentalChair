using Dorisoy.DentalChair.Common;
using Dorisoy.DentalChair.Data;
using ChairData = Dorisoy.DentalChair.Models.ChairData;

namespace Dorisoy.DentalChair.Protocols;

/// <summary>
/// 自定义RS232串口，用于协议通信采集抽象基类
/// </summary>
public abstract class RS232Com : SingletonBase<RS232Com>
{
    /// <summary>
    /// CTS
    /// </summary>
    protected CancellationTokenSource? cts;

    /// <summary>
    /// 用于订阅角度变化
    /// </summary>
    public event EventHandler<int>? AngleChanged;
    protected virtual void OnAngleChanged(int value) => AngleChanged?.Invoke(this, value);

    /// <summary>
    /// 用于订阅高度变化
    /// </summary>
    public event EventHandler<int>? HeightChanged;
    protected virtual void OnHeightChanged(int value) => HeightChanged?.Invoke(this, value);

    /// <summary>
    /// 用于订阅水温变化
    /// </summary>
    public event EventHandler<int>? WaterTemperatureChanged;
    protected virtual void OnWaterTemperatureChanged(int value) => WaterTemperatureChanged?.Invoke(this, value);

    /// <summary>
    /// 用于订阅水压变化
    /// </summary>
    public event EventHandler<int>? WaterPressureChanged;
    protected virtual void OnWaterPressureChanged(int value) => WaterPressureChanged?.Invoke(this, value);

    /// <summary>
    /// 用于订阅气压变化
    /// </summary>
    public event EventHandler<int>? AirPressureChanged;
    protected virtual void OnAirPressureChanged(int value) => AirPressureChanged?.Invoke(this, value);

    /// <summary>
    /// 用于订阅电压变化
    /// </summary>
    public event EventHandler<int>? VoltageChanged;
    protected virtual void OnVoltageChanged(int value) => VoltageChanged?.Invoke(this, value);

    /// <summary>
    /// 用于订阅电流变化
    /// </summary>
    public event EventHandler<double>? CurrentChanged;
    protected virtual void OnCurrentChanged(double value) => CurrentChanged?.Invoke(this, value);

    /// <summary>
    /// 用于订阅提枪动作
    /// </summary>
    public event EventHandler<ChairData>? DentalHandpieceChanged;
    protected virtual void OnDentalHandpieceChanged(ChairData value) => DentalHandpieceChanged?.Invoke(this, value);

    /// <summary>
    /// 连接到串口
    /// </summary>
    /// <param name="portName"></param>
    /// <param name="baudRate"></param>
    /// <param name="dataBits"></param>
    public abstract void Open(string portName, int baudRate, int dataBits);

    /// <summary>
    /// 发送数据
    /// </summary>
    /// <param name="data"></param>
    protected abstract void Send(byte[]? data = null);

    /// <summary>
    /// 指定指令发送数据
    /// </summary>
    /// <param name="data"></param>
    protected abstract void Send(ProtocolType protocolType, byte[]? data = null);

    /// <summary>
    /// 断开串口
    /// </summary>
    public abstract void Close();
}
