
namespace Dorisoy.DentalChair.Services;

/// <summary>
/// 用于模拟数据提供服务
/// </summary>
public class MockServices
{
    static MockServices _instance;

    /// <summary>
    /// 创建单例
    /// </summary>
    public static MockServices Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MockServices();

            return _instance;
        }
    }

    public static readonly Random Random = new Random();
    public List<Color> Colors { get; } = new List<Color>()
    {
        Color.FromArgb("#7644ad"),
        Color.FromArgb("#d54381"),
        Color.FromArgb("#E88F1A"),
        Color.FromArgb("#8010E0"),
        Color.FromArgb("#7ed321"),
        Color.FromArgb("#ff4a4a"),
        Color.FromArgb("#ff844a"),
        Color.FromArgb("#4acaff"),
        Color.FromArgb("#567cd7"),
        Color.FromArgb("#523ee8"),
        Color.FromArgb("#35c659"),
        Color.FromArgb("#d483fc")
    };

    public UserInfo GetUserInfo
    {
        get
        {
            return new UserInfo
            {
                Name = "Dorisoy.DentalChair Dorisoy",
                Email = "master@Dorisoy.DentalChair.cn",
                Avatar = "my.jpg"
            };
        }
    }
    public List<Notification> GetNotifications
    {
        get
        {
            return new List<Notification>
            {
                new Notification
                {
                    Title = "You Get Cashback!",
                    Description = "You get $5 cashback from payment!",
                    Icon = ""
                }
            };
        }
    }
    public List<TransactionData> GetTransactions
    {
        get
        {
            return new List<TransactionData>
            {
                new TransactionData
                {
                    ImageIcon = MauiKitIcons.Cash,
                    IconColor = Color.FromArgb("#d54381"),
                    Title = "Salary",
                    Date = "3:05 PM - Aug 22, 2022",
                    Amount = 4789.89,
                    IsCredited = true
                }
            };
        }
    }

    public List<WalletContact> GetContacts
    {
        get
        {
            return new List<WalletContact>
            {
                new WalletContact
                {
                    Name = "Alaya Cordova",
                    Avatar = "150-1.jpg",
                    PhoneNumber = "324-157-3235"
                }
            };
        }
    }

}
