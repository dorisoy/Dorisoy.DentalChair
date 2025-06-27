namespace Dorisoy.DentalChair.Data
{
    /// <summary>
    /// 提醒信息类
    /// </summary>
    public class NoticeData(int disinfectionDay, int maintenanceDay, long lastMaintenance, long lastDisinfection, long noticeTime)
    {
        /// <summary>
        /// 消毒天数
        /// </summary>
        public int DisinfectionDay { get; set; } = disinfectionDay;
        /// <summary>
        /// 保养天数
        /// </summary>
        public int MaintenanceDay { get; set; } = maintenanceDay;
        /// <summary>
        /// 上次保养时间
        /// </summary>
        public long LastMaintenance { get; set; } = lastMaintenance;
        /// <summary>
        /// 上次消毒时间
        /// </summary>
        public long LastDisinfection { get; set; } = lastDisinfection;
        /// <summary>
        /// 通知时间
        /// </summary>
        public long NoticeTime { get; set; } = noticeTime;
    }
}
