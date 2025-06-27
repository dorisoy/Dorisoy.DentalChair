
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Dorisoy.DentalChair.ViewModels.Base
{
    /// <summary>
    /// 视图模型基类
    /// </summary>
    public partial class BaseViewModel : ObservableObject
    {
        protected readonly SettingsService _settingsService;
        protected readonly DatabaseService _databaseService;

        [ObservableProperty]
        public bool _isBusy;

        [ObservableProperty]
        public int _position;

        [ObservableProperty]
        public User? _user;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="settingsService"></param>
        /// <param name="databaseService"></param>
        public BaseViewModel(SettingsService settingsService, DatabaseService databaseService)
        {
            _settingsService = settingsService;
            _databaseService = databaseService;
        }

        /// <summary>
        /// 虚方法，用于派生类重写异步数据加载方法
        /// </summary>
        /// <returns></returns>
        public virtual Task LoadDataAsync() { return Task.CompletedTask; }

        /// <summary>
        /// 取消注册
        /// </summary>
        /// <returns></returns>
        public virtual Task UnregisterAsync() { return Task.CompletedTask; }

        [RelayCommand]
        private void Next()
        {
            if (Position >= 1)
                Position--;
            else
                Position++;
        }
    }
}
