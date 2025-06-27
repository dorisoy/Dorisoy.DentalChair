namespace Dorisoy.DentalChair.Common
{
    /// <summary>
    /// 用于构建单例基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonBase<T> where T : SingletonBase<T>
    {
        /*
        /// <summary>
        /// 静态实例
        /// </summary>
        private static T? instance;

        /// <summary>
        /// 获取单例实例
        /// </summary>
        public static T? Instance
        {
            get
            {
                lock (typeof(SingletonBase<T>))
                {
                    if (instance == null)
                    {
                        instance ??= Activator.CreateInstance(typeof(T), true) as T;
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// 其它基类方法
        /// </summary>
        public virtual void BaseMethod()
        {
            // 实现逻辑
        }
        */


        /// <summary>
        /// 优化，使用懒加载，提高线程安全性，减少锁的性能开销
        /// </summary>
        private static readonly Lazy<T> lazyInstance = new(() => (Activator.CreateInstance(typeof(T), true) as T)!);

        /// <summary>
        /// 获取单例实例
        /// </summary>
        public static T Instance => lazyInstance.Value;

        /// <summary>
        /// 其它基类方法
        /// </summary>
        public virtual void BaseMethod()
        {
            // 实现逻辑
        }
    }
}
