namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 牙椅用户存储类
/// </summary>
[Serializable]
public class UserData(string id,
    string name,
    string card,
    long loginTime,
    long outTime,
    List<ConfigData> list,
    List<bool>? linkage,
    List<ChairData>? chairData,
    int fiberLight = 14,
    int flush = 1,
    int temperature = 30,
    int cup = 5,
    int water = 1)
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public string Id { get; } = id;
    /// <summary>
    /// 用户名
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// 卡片
    /// </summary>
    public string Card { get; set; } = card;

    /// <summary>
    /// 登录时间
    /// </summary>
    public long LoginTime { get; set; } = loginTime;

    /// <summary>
    /// 退出时间
    /// </summary>
    public long OutTime { get; set; } = outTime;

    /// <summary>
    /// 配置列表
    /// </summary>
    public List<ConfigData> List { get; set; } = list;

    /// <summary>
    /// 联动
    /// </summary>
    public List<bool>? Linkage { get; set; } = linkage;

    /// <summary>
    /// 椅位数据
    /// </summary>
    public List<ChairData>? ChairData { get; set; } = chairData;

    /// <summary>
    /// 光纤灯亮度
    /// </summary>
    public int FiberLight { get; set; } = fiberLight;

    /// <summary>
    /// 冲洗
    /// </summary>
    public int Flush { get; set; } = flush;

    /// <summary>
    /// 温度
    /// </summary>
    public int Temperature { get; set; } = temperature;

    /// <summary>
    /// 杯水
    /// </summary>
    public int Cup { get; set; } = cup;

    /// <summary>
    /// 水量
    /// </summary>
    public int Water { get; set; } = water;
}
