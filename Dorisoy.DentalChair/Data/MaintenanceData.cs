namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 保养类
/// </summary>
public class MaintenanceData(string maintenanceType, string reminderMessage, string nextMaintenanceDate)
{
    /// <summary>
    /// 保养类型
    /// </summary>
    public string MaintenanceType { get; } = maintenanceType;
    /// <summary>
    /// 提醒消息
    /// </summary>
    public string ReminderMessage { get; } = reminderMessage;
    /// <summary>
    /// 下次保养日期
    /// </summary>
    public string NextMaintenanceDate { get; } = nextMaintenanceDate;
}
