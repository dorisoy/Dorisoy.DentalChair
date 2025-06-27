namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 更新数据类
/// </summary>
public class UpdateData
{
    public int FileId { get; }         // 文件ID
    public string DownloadUrl { get; } // 下载URL
    public string Version { get; }     // 版本
    public bool Enable { get; }        // 是否启用

    public UpdateData(int fileId, string downloadUrl, string version, bool enable)
    {
        FileId = fileId;
        DownloadUrl = downloadUrl;
        Version = version;
        Enable = enable;
    }
}
