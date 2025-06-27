namespace Dorisoy.DentalChair;

public static class ViewHelper
{
    /// <summary>
    /// 根据样式ID遍历父级布局查找子视图元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <param name="styleId"></param>
    /// <returns></returns>
    public static List<T> FindChildrenByStyleId<T>(Layout parent, string styleId) where T : View
    {
        // 用于存储匹配的视图
        List<T> matchingViews = [];
        // 遍历父布局的所有子视图
        foreach (var child in parent.Children)
        {
            // 如果子视图是指定类型且 StyleId 匹配
            if (child is T typedChild && typedChild.StyleId == styleId)
            {
                // 将匹配的视图添加到结果列表
                matchingViews.Add(typedChild);
            }
            // 检查子视图是否也是 Layout 类型
            if (child is Layout layoutChild)
            {
                // 递归查找子布局中的匹配视图
                var nestedResults = FindChildrenByStyleId<T>(layoutChild, styleId);
                // 将嵌套结果添加到结果列表
                matchingViews.AddRange(nestedResults);
            }
        }
        // 返回所有匹配的视图
        return matchingViews;
    }
}
