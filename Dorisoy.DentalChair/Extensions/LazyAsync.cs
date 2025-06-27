using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dorisoy.DentalChair.Extensions
{

    /// <summary>
    /// 用于延迟加载
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LazyAsync<T>
    {
        readonly Lazy<Task<T>> instance;
        public LazyAsync(Func<T> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        public LazyAsync(Func<Task<T>> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        public TaskAwaiter<T> GetAwaiter()
        {
            return instance.Value.GetAwaiter();
        }
    }
}
