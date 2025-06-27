namespace Dorisoy.DentalChair.Data;


/// <summary>
/// 反馈类型枚举
/// </summary>
public enum FeedbackType
{
    None = 0,
    PickUp = 1,
    PickDown = 2,
    PedalPressed = 3,
    PedalReleased = 4,
    Power = 5,
    Speed = 7,
    Assistant = 8,
    Chair = 9
}

/// <summary>
/// 反馈类型扩展
/// </summary>
public static class FeedbackTypeExtensions
{
    private static readonly Dictionary<int, FeedbackType> map = new()
    {
       { 0,FeedbackType.None },
       { 1,FeedbackType.PickUp },
       { 2,FeedbackType.PickDown },
       { 3,FeedbackType.PedalPressed },
       { 4,FeedbackType.PedalReleased },
       { 5,FeedbackType.Power },
       { 7,FeedbackType.Speed },
       { 8,FeedbackType.Assistant },
       { 9,FeedbackType.Chair }
    };

    public static FeedbackType FromInt(int type)
    {
        return map.TryGetValue(type, out var feedbackType) ? feedbackType : FeedbackType.None;
    }
}
