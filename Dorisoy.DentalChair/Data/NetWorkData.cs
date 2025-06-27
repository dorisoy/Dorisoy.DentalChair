namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 网络设置类
/// </summary>
[Serializable]
public class NetWorkData(string topic, string ip, string user, int port, string pass, bool proxy = false)
{
    /// <summary>
    /// 主题
    /// </summary>
    public string Topic { get; set; } = topic;
    /// <summary>
    /// IP地址
    /// </summary>
    public string Ip { get; set; } = ip;
    /// <summary>
    /// 用户
    /// </summary>
    public string User { get; set; } = user;
    /// <summary>
    /// 端口
    /// </summary>
    public int Port { get; set; } = port;
    /// <summary>
    /// 密码
    /// </summary>
    public string Pass { get; set; } = pass;
    /// <summary>
    /// 是否使用代理
    /// </summary>
    public bool Proxy { get; set; } = proxy;
}
