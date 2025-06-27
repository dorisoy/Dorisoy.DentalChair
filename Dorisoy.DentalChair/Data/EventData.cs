namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 故障类
/// </summary>
public class EventData(string @event, string errorCode, string errorMessage, long time, bool isCheck)
{
    /// <summary>
    /// 事件
    /// </summary>
    public string Event { get; } = @event;

    /// <summary>
    /// 错误代码
    /// </summary>
    public string ErrorCode { get; } = errorCode;

    /// <summary>
    /// 错误信息
    /// </summary>
    public string ErrorMessage { get; } = errorMessage;

    /// <summary>
    /// 时间（以毫秒为单位）
    /// </summary>
    public long Time { get; } = time;

    /// <summary>
    /// 是否检查
    /// </summary>
    public bool IsCheck { get; set; } = isCheck;
}
