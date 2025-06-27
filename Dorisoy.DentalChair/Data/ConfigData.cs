namespace Dorisoy.DentalChair.Data;

/// <summary>
/// 配置存储
/// </summary>
[Serializable]
public class ConfigData(bool fiber, bool variable, bool speed, bool direction, int power)
{
    /// <summary>
    /// 光纤
    /// </summary>
    public bool Fiber { get; set; } = fiber;

    /// <summary>
    /// 是否可变
    /// </summary>
    public bool Variable { get; set; } = variable;

    /// <summary>
    /// 速度
    /// </summary>
    public bool Speed { get; set; } = speed;

    /// <summary>
    /// 方向
    /// </summary>
    public bool Direction { get; set; } = direction;

    /// <summary>
    ///  功率
    /// </summary>
    public int Power { get; set; } = power;
}
